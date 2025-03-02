﻿/*
 * Copyright © 2016 - 2019 EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 * 
 * EDDiscovery is not affiliated with Frontier Developments plc.
 */
using EliteDangerousCore;
using EliteDangerousCore.DB;
using EliteDangerousCore.EDSM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EDDiscovery.UserControls
{
    public partial class UserControlStarDistance : UserControlCommonBase
    {
        public UserControlStarDistance()
        {
            InitializeComponent();
        }

        private StarDistanceComputer computer = null;
        private HistoryEntry last_he = null;

        private const double defaultMaxRadius = 100;
        private const double defaultMinRadius = 0;
        private const int maxitems = 500;

        private double lookup_limit = 100;      // we start with a reasonable number, because if your in the bubble, you don't want to be looking up 1000

        public override void Init()
        {
            DBBaseName = "StarDistancePanel";

            computer = new StarDistanceComputer();

            textMinRadius.ValueNoChange = GetSetting("Min", defaultMinRadius);
            textMaxRadius.ValueNoChange = GetSetting("Max", defaultMaxRadius);
            textMinRadius.SetComparitor(textMaxRadius, -2);     // need to do this after values are set
            textMaxRadius.SetComparitor(textMinRadius, 2);

            checkBoxCube.Checked = GetSetting("Behaviour", false);

            var enumlist = new Enum[] { EDTx.UserControlStarDistance_colName, EDTx.UserControlStarDistance_colDistance, EDTx.UserControlStarDistance_colVisited, EDTx.UserControlStarDistance_labelExtMin, EDTx.UserControlStarDistance_labelExtMax, EDTx.UserControlStarDistance_checkBoxCube };
            var enumlistcms = new Enum[] { EDTx.UserControlStarDistance_viewSystemToolStripMenuItem, EDTx.UserControlStarDistance_viewOnEDSMToolStripMenuItem1, EDTx.UserControlStarDistance_addToTrilaterationToolStripMenuItem1, EDTx.UserControlStarDistance_addToExpeditionToolStripMenuItem };
            var enumlisttt = new Enum[] { EDTx.UserControlStarDistance_textMinRadius_ToolTip, EDTx.UserControlStarDistance_textMaxRadius_ToolTip, EDTx.UserControlStarDistance_checkBoxCube_ToolTip };
            BaseUtils.Translator.Instance.TranslateControls(this, enumlist);
            BaseUtils.Translator.Instance.TranslateToolstrip(contextMenuStrip, enumlistcms, this);
            BaseUtils.Translator.Instance.TranslateTooltip(toolTip, enumlisttt, this);
        }

        public override void ChangeCursorType(IHistoryCursor thc)
        {
            uctg.OnTravelSelectionChanged -= Uctg_OnTravelSelectionChanged;
            uctg = thc;
            uctg.OnTravelSelectionChanged += Uctg_OnTravelSelectionChanged;
        }

        public override void LoadLayout()
        {
            DGVLoadColumnLayout(dataGridViewNearest);

            discoveryform.OnHistoryChange += Discoveryform_OnHistoryChange;
            uctg.OnTravelSelectionChanged += Uctg_OnTravelSelectionChanged;
        }

        public override void Closing()
        {
            DGVSaveColumnLayout(dataGridViewNearest);
            discoveryform.OnHistoryChange -= Discoveryform_OnHistoryChange;
            uctg.OnTravelSelectionChanged -= Uctg_OnTravelSelectionChanged;
            computer.ShutDown();
            PutSetting("Min", textMinRadius.Value);
            PutSetting("Max", textMaxRadius.Value);
            PutSetting("Behaviour", checkBoxCube.Checked);

        }

        public override void InitialDisplay()
        {
            KickComputation(uctg.GetCurrentHistoryEntry, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void Discoveryform_OnHistoryChange(HistoryList obj)
        {
            KickComputation(obj.GetLast);   // copes with getlast = null
        }

        private void Uctg_OnTravelSelectionChanged(HistoryEntry he, HistoryList hl, bool selectedEntry)
        {
            KickComputation(he);
        }

        private void KickComputation(HistoryEntry he, bool force = false)
        {
            if (he != null && he.System != null && (force || !he.System.Equals(last_he?.System)))
            {
                last_he = he;

                //System.Diagnostics.Debug.WriteLine("Star grid started, uctg selected, ask");

                double lookup_max = Math.Min(textMaxRadius.Value, lookup_limit);
                //System.Diagnostics.Debug.WriteLine("Lookup limit " + lookup_limit + " lookup " + lookup_max);

                // Get nearby systems from the systems DB.
                computer.CalculateClosestSystems(he.System,
                    NewStarListComputedAsync,
                    maxitems, textMinRadius.Value, lookup_max, !checkBoxCube.Checked
                    );     // hook here, force closes system update


            }
        }

        private void NewStarListComputedAsync(ISystem sys, BaseUtils.SortedListDoubleDuplicate<ISystem> list)
        {
            //System.Diagnostics.Debug.WriteLine("Computer returned " + list.Count);
            this.ParentForm.BeginInvoke(new Action(() => NewStarListComputed(sys, list)));
        }

        private void NewStarListComputed(ISystem sys, BaseUtils.SortedListDoubleDuplicate<ISystem> list)      // In UI
        {
            System.Diagnostics.Debug.Assert(Application.MessageLoop);       // check!

            //System.Diagnostics.Debug.WriteLine(BaseUtils.AppTicks.TickCountLapDelta("SD1", true) + "SD main thread");

            double lookup_max = Math.Min(textMaxRadius.Value, lookup_limit);

            // Get nearby systems from our travel history. This will filter out duplicates from the systems DB.
            discoveryform.history.CalculateSqDistances(list, sys.X, sys.Y, sys.Z,
                                maxitems, textMinRadius.Value, lookup_max, !checkBoxCube.Checked, 5000);       // only go back a sensible number of FSD entries

            FillGrid(sys.Name, list);

            //System.Diagnostics.Debug.WriteLine(BaseUtils.AppTicks.TickCountLapDelta("SD1") + "SD  finish");
        }

        private void FillGrid(string name, BaseUtils.SortedListDoubleDuplicate<ISystem> csl)
        {
            DataGridViewColumn sortcolprev = dataGridViewNearest.SortedColumn != null ? dataGridViewNearest.SortedColumn : dataGridViewNearest.Columns[1];
            SortOrder sortorderprev = dataGridViewNearest.SortedColumn != null ? dataGridViewNearest.SortOrder : SortOrder.Ascending;

            dataViewScrollerPanel.Suspend();
            dataGridViewNearest.Rows.Clear();

            if (csl != null && csl.Any())
            {
                SetControlText(string.Format("From {0}".T(EDTx.UserControlStarDistance_From), name));

                List<DataGridViewRow> rows = new List<DataGridViewRow>();

                int maxdist = 0;
                foreach (KeyValuePair<double, ISystem> tvp in csl)
                {
                    double dist = Math.Sqrt(tvp.Key);   // distances are stored squared for speed, back to normal.

                    maxdist = Math.Max(maxdist, (int)dist);

                    if (tvp.Value.Name != name && (checkBoxCube.Checked || (dist >= textMinRadius.Value && dist <= textMaxRadius.Value)))
                    {
                        int visits = discoveryform.history.GetVisitsCount(tvp.Value.Name);
                        object[] rowobj = { tvp.Value.Name, $"{dist:0.00}", $"{visits:n0}" };

                        var rw = dataGridViewNearest.RowTemplate.Clone() as DataGridViewRow;
                        rw.CreateCells(dataGridViewNearest, rowobj);
                        rw.Tag = tvp.Value; 
                        rows.Add(rw);
                    }
                }

                dataGridViewNearest.Rows.AddRange(rows.ToArray());

                if (csl.Count > maxitems / 2)           // if we filled up at least half the list, we limit to max distance plus
                {
                    lookup_limit = maxdist * 11 / 10;   // lookup limit is % more than max dist, to allow for growth
                }
                else if ( csl.Count > maxitems / 10 )
                    lookup_limit = maxdist * 2;         // else we did not get close to filling the list, so double the limit and try again
                else
                    lookup_limit = 100;                 // got so few, lets reset

                System.Diagnostics.Debug.WriteLine("Star distance Lookup " + name + " found " + csl.Count + " max was " + maxdist + " New limit " + lookup_limit);
            }
            else
            {
                SetControlText(string.Empty);
            }

            if ( sortcolprev != colDistance || sortorderprev != SortOrder.Ascending )   // speed optimising, only sort if not in sort order from distances
                dataGridViewNearest.Sort(sortcolprev, (sortorderprev == SortOrder.Descending) ? ListSortDirection.Descending : ListSortDirection.Ascending);

            dataGridViewNearest.Columns[sortcolprev.Index].HeaderCell.SortGlyphDirection = sortorderprev;

            dataViewScrollerPanel.Resume();
        }

        private void dataGridViewNearest_MouseDown(object sender, MouseEventArgs e)
        {
            viewOnEDSMToolStripMenuItem1.Enabled = dataGridViewNearest.RightClickRowValid;
        }

        private void addToTrilaterationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddTo(OnNewStarsPushType.TriSystems);
        }

        private void addToExpeditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTo(OnNewStarsPushType.Expedition);

        }

        private void AddTo(OnNewStarsPushType pushtype)
        {
            IEnumerable<DataGridViewRow> selectedRows = dataGridViewNearest.SelectedCells.Cast<DataGridViewCell>()
                                                                        .Select(cell => cell.OwningRow)
                                                                        .Distinct()
                                                                        .OrderBy(cell => cell.Index);

            List<string> syslist = new List<string>();
            foreach (DataGridViewRow r in selectedRows)
                syslist.Add(r.Cells[0].Value.ToString());

            if (uctg is IHistoryCursorNewStarList)
                (uctg as IHistoryCursorNewStarList).FireNewStarList(syslist, pushtype);
        }

        private void viewOnEDSMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridViewNearest.RightClickRowValid) 
            {
                var rightclicksystem = (ISystem)dataGridViewNearest.Rows[dataGridViewNearest.RightClickRow].Tag;

                if (rightclicksystem != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    EDSMClass edsm = new EDSMClass();
                    if (!edsm.ShowSystemInEDSM(rightclicksystem.Name))
                    {
                        ExtendedControls.MessageBoxTheme.Show(FindForm(), "System could not be found - has not been synched or EDSM is unavailable".T(EDTx.UserControlStarDistance_NoEDSMSys));
                    }

                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void dataGridViewNearest_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index >= 1)
                e.SortDataGridViewColumnNumeric();
        }

        private void checkBoxCube_CheckedChanged(object sender, EventArgs e)
        {
            KickComputation(last_he, true);
        }

        private void textMinRadius_ValueChanged(object sender, EventArgs e)
        {
            lookup_limit = textMaxRadius.Value;
            KickComputation(last_he, true);
        }

        private void textMaxRadius_ValueChanged(object sender, EventArgs e)
        {
            lookup_limit = textMaxRadius.Value;
            KickComputation(last_he, true);
        }

        private void dataGridViewNearest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex < dataGridViewNearest.Rows.Count)
            {
                Clipboard.SetText(dataGridViewNearest.Rows[e.RowIndex].Cells[0].Value as string);
            }
        }

        private void viewSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewNearest.RightClickRowValid)
            {
                var rightclicksystem = (ISystem)dataGridViewNearest.Rows[dataGridViewNearest.RightClickRow].Tag;

                if ( rightclicksystem != null )
                    ScanDisplayForm.ShowScanOrMarketForm(this.FindForm(), rightclicksystem, true, discoveryform.history);
            }
        }

        private void dataGridViewNearest_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewNearest.Rows.Count)
            { 
                var clicksystem = (ISystem)dataGridViewNearest.Rows[e.RowIndex].Tag;
                if ( clicksystem != null )
                    ScanDisplayForm.ShowScanOrMarketForm(this.FindForm(), clicksystem, true, discoveryform.history);
            }

        }
    }
}
