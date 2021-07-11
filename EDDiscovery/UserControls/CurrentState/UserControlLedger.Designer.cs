﻿/*
 * Copyright © 2016 - 2017 EDDiscovery development team
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
namespace EDDiscovery.UserControls
{
    partial class UserControlLedger
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlLedger));
            this.dataViewScrollerPanel = new ExtendedControls.ExtPanelDataGridViewScroll();
            this.dataGridViewLedger = new BaseUtils.DataGridViewColumnHider();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemGotoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBarCustomMC = new ExtendedControls.ExtScrollBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonFilter = new ExtendedControls.ExtButton();
            this.textBoxFilter = new ExtendedControls.ExtTextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.comboBoxHistoryWindow = new ExtendedControls.ExtComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonExtExcel = new ExtendedControls.ExtButton();
            this.topPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Debits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataViewScrollerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLedger)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataViewScrollerPanel
            // 
            this.dataViewScrollerPanel.Controls.Add(this.dataGridViewLedger);
            this.dataViewScrollerPanel.Controls.Add(this.vScrollBarCustomMC);
            this.dataViewScrollerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewScrollerPanel.InternalMargin = new System.Windows.Forms.Padding(0);
            this.dataViewScrollerPanel.Location = new System.Drawing.Point(0, 30);
            this.dataViewScrollerPanel.Name = "dataViewScrollerPanel";
            this.dataViewScrollerPanel.Size = new System.Drawing.Size(800, 542);
            this.dataViewScrollerPanel.TabIndex = 0;
            this.dataViewScrollerPanel.VerticalScrollBarDockRight = true;
            // 
            // dataGridViewLedger
            // 
            this.dataGridViewLedger.AllowUserToAddRows = false;
            this.dataGridViewLedger.AllowUserToDeleteRows = false;
            this.dataGridViewLedger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLedger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeCol,
            this.Type,
            this.Notes,
            this.Credits,
            this.Debits,
            this.Balance,
            this.NormProfit,
            this.TotalProfit});
            this.dataGridViewLedger.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLedger.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLedger.Name = "dataGridViewLedger";
            this.dataGridViewLedger.RowHeaderMenuStrip = null;
            this.dataGridViewLedger.RowHeadersVisible = false;
            this.dataGridViewLedger.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewLedger.SingleRowSelect = true;
            this.dataGridViewLedger.Size = new System.Drawing.Size(784, 542);
            this.dataGridViewLedger.TabIndex = 1;
            this.dataGridViewLedger.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridViewLedger_SortCompare);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGotoItem});
            this.contextMenuStrip.Name = "contextMenuStripLedger";
            this.contextMenuStrip.Size = new System.Drawing.Size(175, 26);
            // 
            // toolStripMenuItemGotoItem
            // 
            this.toolStripMenuItemGotoItem.Name = "toolStripMenuItemGotoItem";
            this.toolStripMenuItemGotoItem.Size = new System.Drawing.Size(174, 22);
            this.toolStripMenuItemGotoItem.Text = "Go to entry on grid";
            this.toolStripMenuItemGotoItem.Click += new System.EventHandler(this.toolStripMenuItemGotoItem_Click);
            // 
            // vScrollBarCustomMC
            // 
            this.vScrollBarCustomMC.ArrowBorderColor = System.Drawing.Color.LightBlue;
            this.vScrollBarCustomMC.ArrowButtonColor = System.Drawing.Color.LightGray;
            this.vScrollBarCustomMC.ArrowColorScaling = 0.5F;
            this.vScrollBarCustomMC.ArrowDownDrawAngle = 270F;
            this.vScrollBarCustomMC.ArrowUpDrawAngle = 90F;
            this.vScrollBarCustomMC.BorderColor = System.Drawing.Color.White;
            this.vScrollBarCustomMC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vScrollBarCustomMC.HideScrollBar = false;
            this.vScrollBarCustomMC.LargeChange = 0;
            this.vScrollBarCustomMC.Location = new System.Drawing.Point(784, 0);
            this.vScrollBarCustomMC.Maximum = -1;
            this.vScrollBarCustomMC.Minimum = 0;
            this.vScrollBarCustomMC.MouseOverButtonColor = System.Drawing.Color.Green;
            this.vScrollBarCustomMC.MousePressedButtonColor = System.Drawing.Color.Red;
            this.vScrollBarCustomMC.Name = "vScrollBarCustomMC";
            this.vScrollBarCustomMC.Size = new System.Drawing.Size(16, 542);
            this.vScrollBarCustomMC.SliderColor = System.Drawing.Color.DarkGray;
            this.vScrollBarCustomMC.SmallChange = 1;
            this.vScrollBarCustomMC.TabIndex = 0;
            this.vScrollBarCustomMC.ThumbBorderColor = System.Drawing.Color.Yellow;
            this.vScrollBarCustomMC.ThumbButtonColor = System.Drawing.Color.DarkBlue;
            this.vScrollBarCustomMC.ThumbColorScaling = 0.5F;
            this.vScrollBarCustomMC.ThumbDrawAngle = 0F;
            this.vScrollBarCustomMC.Value = -1;
            this.vScrollBarCustomMC.ValueLimited = -1;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(0, 1);
            this.labelTime.Margin = new System.Windows.Forms.Padding(0, 1, 8, 1);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 26;
            this.labelTime.Text = "Time";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Image = global::EDDiscovery.Icons.Controls.TravelGrid_EventFilter;
            this.buttonFilter.Location = new System.Drawing.Point(351, 1);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(0, 1, 8, 1);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(28, 28);
            this.buttonFilter.TabIndex = 25;
            this.toolTip.SetToolTip(this.buttonFilter, "Display entries matching this event type filter");
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBoxFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBoxFilter.BackErrorColor = System.Drawing.Color.Red;
            this.textBoxFilter.BorderColor = System.Drawing.Color.Transparent;
            this.textBoxFilter.BorderColorScaling = 0.5F;
            this.textBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilter.ClearOnFirstChar = false;
            this.textBoxFilter.ControlBackground = System.Drawing.SystemColors.Control;
            this.textBoxFilter.EndButtonEnable = true;
            this.textBoxFilter.EndButtonImage = ((System.Drawing.Image)(resources.GetObject("textBoxFilter.EndButtonImage")));
            this.textBoxFilter.EndButtonVisible = false;
            this.textBoxFilter.InErrorCondition = false;
            this.textBoxFilter.Location = new System.Drawing.Point(195, 1);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(0, 1, 8, 1);
            this.textBoxFilter.Multiline = false;
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.ReadOnly = false;
            this.textBoxFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxFilter.SelectionLength = 0;
            this.textBoxFilter.SelectionStart = 0;
            this.textBoxFilter.Size = new System.Drawing.Size(148, 20);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip.SetToolTip(this.textBoxFilter, "Search to particular items");
            this.textBoxFilter.WordWrap = true;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(146, 1);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(0, 1, 8, 1);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(41, 13);
            this.labelSearch.TabIndex = 24;
            this.labelSearch.Text = "Search";
            // 
            // comboBoxHistoryWindow
            // 
            this.comboBoxHistoryWindow.BorderColor = System.Drawing.Color.Red;
            this.comboBoxHistoryWindow.ButtonColorScaling = 0.5F;
            this.comboBoxHistoryWindow.DataSource = null;
            this.comboBoxHistoryWindow.DisableBackgroundDisabledShadingGradient = false;
            this.comboBoxHistoryWindow.DisplayMember = "";
            this.comboBoxHistoryWindow.DropDownBackgroundColor = System.Drawing.Color.Gray;
            this.comboBoxHistoryWindow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxHistoryWindow.Location = new System.Drawing.Point(38, 1);
            this.comboBoxHistoryWindow.Margin = new System.Windows.Forms.Padding(0, 1, 8, 1);
            this.comboBoxHistoryWindow.MouseOverBackgroundColor = System.Drawing.Color.Silver;
            this.comboBoxHistoryWindow.Name = "comboBoxHistoryWindow";
            this.comboBoxHistoryWindow.ScrollBarButtonColor = System.Drawing.Color.LightGray;
            this.comboBoxHistoryWindow.ScrollBarColor = System.Drawing.Color.LightGray;
            this.comboBoxHistoryWindow.SelectedIndex = -1;
            this.comboBoxHistoryWindow.SelectedItem = null;
            this.comboBoxHistoryWindow.SelectedValue = null;
            this.comboBoxHistoryWindow.Size = new System.Drawing.Size(100, 21);
            this.comboBoxHistoryWindow.TabIndex = 0;
            this.comboBoxHistoryWindow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.comboBoxHistoryWindow, "Select the entries by age");
            this.comboBoxHistoryWindow.ValueMember = "";
            this.comboBoxHistoryWindow.SelectedIndexChanged += new System.EventHandler(this.comboBoxHistoryWindow_SelectedIndexChanged);
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // buttonExtExcel
            // 
            this.buttonExtExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExtExcel.Image = global::EDDiscovery.Icons.Controls.JournalGrid_ExportToExcel;
            this.buttonExtExcel.Location = new System.Drawing.Point(387, 1);
            this.buttonExtExcel.Margin = new System.Windows.Forms.Padding(0, 1, 8, 1);
            this.buttonExtExcel.Name = "buttonExtExcel";
            this.buttonExtExcel.Size = new System.Drawing.Size(28, 28);
            this.buttonExtExcel.TabIndex = 32;
            this.toolTip.SetToolTip(this.buttonExtExcel, "Send data on grid to excel");
            this.buttonExtExcel.UseVisualStyleBackColor = true;
            this.buttonExtExcel.Click += new System.EventHandler(this.buttonExtExcel_Click);
            // 
            // topPanel
            // 
            this.topPanel.AutoSize = true;
            this.topPanel.Controls.Add(this.labelTime);
            this.topPanel.Controls.Add(this.comboBoxHistoryWindow);
            this.topPanel.Controls.Add(this.labelSearch);
            this.topPanel.Controls.Add(this.textBoxFilter);
            this.topPanel.Controls.Add(this.buttonFilter);
            this.topPanel.Controls.Add(this.buttonExtExcel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 30);
            this.topPanel.TabIndex = 2;
            // 
            // TimeCol
            // 
            this.TimeCol.HeaderText = "Time";
            this.TimeCol.MinimumWidth = 50;
            this.TimeCol.Name = "TimeCol";
            this.TimeCol.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 80;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Notes
            // 
            this.Notes.FillWeight = 200F;
            this.Notes.HeaderText = "Notes";
            this.Notes.MinimumWidth = 80;
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // Credits
            // 
            this.Credits.HeaderText = "Credits";
            this.Credits.MinimumWidth = 80;
            this.Credits.Name = "Credits";
            this.Credits.ReadOnly = true;
            // 
            // Debits
            // 
            this.Debits.HeaderText = "Debits";
            this.Debits.MinimumWidth = 80;
            this.Debits.Name = "Debits";
            this.Debits.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.HeaderText = "Balance";
            this.Balance.MinimumWidth = 80;
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // NormProfit
            // 
            this.NormProfit.HeaderText = "Profit Per Unit";
            this.NormProfit.MinimumWidth = 20;
            this.NormProfit.Name = "NormProfit";
            // 
            // TotalProfit
            // 
            this.TotalProfit.HeaderText = "Total Profit";
            this.TotalProfit.MinimumWidth = 80;
            this.TotalProfit.Name = "TotalProfit";
            this.TotalProfit.ReadOnly = true;
            // 
            // UserControlLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataViewScrollerPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "UserControlLedger";
            this.Size = new System.Drawing.Size(800, 572);
            this.dataViewScrollerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLedger)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedControls.ExtPanelDataGridViewScroll dataViewScrollerPanel;
        private BaseUtils.DataGridViewColumnHider dataGridViewLedger;
        private ExtendedControls.ExtScrollBar vScrollBarCustomMC;
        private ExtendedControls.ExtButton buttonFilter;
        internal ExtendedControls.ExtComboBox comboBoxHistoryWindow;
        private System.Windows.Forms.Label labelSearch;
        private ExtendedControls.ExtTextBox textBoxFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGotoItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.FlowLayoutPanel topPanel;
        private ExtendedControls.ExtButton buttonExtExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Debits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalProfit;
    }
}
