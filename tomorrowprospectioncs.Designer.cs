namespace RibbonSimplePad
{
    partial class tomorrowprospectioncs
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.arrangeBar1 = new DevExpress.XtraScheduler.UI.ArrangeBar();
            this.arrangeBar2 = new DevExpress.XtraScheduler.UI.ArrangeBar();
            this.arrangeBar3 = new DevExpress.XtraScheduler.UI.ArrangeBar();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.xtraTabControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(758, 411);
            this.panelControl2.TabIndex = 1;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(754, 407);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(748, 379);
            this.xtraTabPage1.Text = "Prospection pour demain";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(748, 379);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // arrangeBar1
            // 
            this.arrangeBar1.BarName = "";
            this.arrangeBar1.Control = null;
            this.arrangeBar1.DockCol = 1;
            this.arrangeBar1.DockRow = 1;
            this.arrangeBar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.arrangeBar1.Offset = 78;
            this.arrangeBar1.OptionsBar.AllowQuickCustomization = false;
            this.arrangeBar1.Text = "";
            // 
            // arrangeBar2
            // 
            this.arrangeBar2.BarName = "";
            this.arrangeBar2.Control = null;
            this.arrangeBar2.DockCol = 1;
            this.arrangeBar2.DockRow = 1;
            this.arrangeBar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.arrangeBar2.Offset = 78;
            this.arrangeBar2.OptionsBar.AllowQuickCustomization = false;
            this.arrangeBar2.Text = "";
            // 
            // arrangeBar3
            // 
            this.arrangeBar3.BarName = "";
            this.arrangeBar3.Control = null;
            this.arrangeBar3.DockCol = 1;
            this.arrangeBar3.DockRow = 1;
            this.arrangeBar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.arrangeBar3.Offset = 78;
            this.arrangeBar3.OptionsBar.AllowQuickCustomization = false;
            this.arrangeBar3.Text = "";
            // 
            // tomorrowprospectioncs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 411);
            this.Controls.Add(this.panelControl2);
            this.Name = "tomorrowprospectioncs";
            this.Text = "Prospections pour demain";
            this.Activated += new System.EventHandler(this.tomorrowprospectioncs_Activated);
            this.Load += new System.EventHandler(this.Historiqueprospectioncs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraScheduler.UI.ArrangeBar arrangeBar1;
        private DevExpress.XtraScheduler.UI.ArrangeBar arrangeBar2;
        private DevExpress.XtraScheduler.UI.ArrangeBar arrangeBar3;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}