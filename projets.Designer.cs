namespace RibbonSimplePad
{
    partial class projets
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(projets));
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl5 = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton9 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton26 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton25 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton22 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton24 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton23 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(804, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 447);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 447);
            this.barDockControlBottom.Size = new System.Drawing.Size(804, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(804, 0);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5});
            this.barManager1.MaxItemId = 6;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 447);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Marquer comme";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "En Négociation";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "En Attente";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Non Remporté";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Remporté";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Fiche technique";
            this.barButtonItem5.Id = 5;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridControl5);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 44);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(804, 403);
            this.panelControl2.TabIndex = 19;
            // 
            // gridControl5
            // 
            this.gridControl5.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl5.Location = new System.Drawing.Point(2, 2);
            this.gridControl5.MainView = this.gridView5;
            this.gridControl5.Name = "gridControl5";
            this.gridControl5.Size = new System.Drawing.Size(800, 399);
            this.gridControl5.TabIndex = 10;
            this.gridControl5.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            this.gridControl5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridControl5_MouseClick);
            // 
            // gridView5
            // 
            this.gridView5.GridControl = this.gridControl5;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.Editable = false;
            this.gridView5.OptionsView.AllowCellMerge = true;
            this.gridView5.RowHeight = 50;
            // 
            // simpleButton9
            // 
            this.simpleButton9.Image = global::RibbonSimplePad.Properties.Resources.sortie_production2;
            this.simpleButton9.Location = new System.Drawing.Point(431, 12);
            this.simpleButton9.Name = "simpleButton9";
            this.simpleButton9.Size = new System.Drawing.Size(96, 23);
            this.simpleButton9.TabIndex = 19;
            this.simpleButton9.Text = "Trier par date";
            this.simpleButton9.Click += new System.EventHandler(this.simpleButton9_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton9);
            this.panelControl1.Controls.Add(this.simpleButton26);
            this.panelControl1.Controls.Add(this.simpleButton25);
            this.panelControl1.Controls.Add(this.simpleButton22);
            this.panelControl1.Controls.Add(this.simpleButton24);
            this.panelControl1.Controls.Add(this.simpleButton23);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(804, 44);
            this.panelControl1.TabIndex = 18;
            // 
            // simpleButton26
            // 
            this.simpleButton26.Image = global::RibbonSimplePad.Properties.Resources.ajouter_icone_5107_16;
            this.simpleButton26.Location = new System.Drawing.Point(107, 12);
            this.simpleButton26.Name = "simpleButton26";
            this.simpleButton26.Size = new System.Drawing.Size(75, 23);
            this.simpleButton26.TabIndex = 11;
            this.simpleButton26.Text = "Ajouter";
            this.simpleButton26.Click += new System.EventHandler(this.simpleButton26_Click);
            // 
            // simpleButton25
            // 
            this.simpleButton25.Image = global::RibbonSimplePad.Properties.Resources.pie_chart_modifier_icone_8023_16;
            this.simpleButton25.Location = new System.Drawing.Point(188, 12);
            this.simpleButton25.Name = "simpleButton25";
            this.simpleButton25.Size = new System.Drawing.Size(75, 23);
            this.simpleButton25.TabIndex = 12;
            this.simpleButton25.Text = "Modifier";
            this.simpleButton25.Click += new System.EventHandler(this.simpleButton25_Click);
            // 
            // simpleButton22
            // 
            this.simpleButton22.Image = global::RibbonSimplePad.Properties.Resources.devis_16;
            this.simpleButton22.Location = new System.Drawing.Point(350, 12);
            this.simpleButton22.Name = "simpleButton22";
            this.simpleButton22.Size = new System.Drawing.Size(75, 23);
            this.simpleButton22.TabIndex = 15;
            this.simpleButton22.Text = "Exporter";
            this.simpleButton22.Click += new System.EventHandler(this.simpleButton22_Click);
            // 
            // simpleButton24
            // 
            this.simpleButton24.Image = global::RibbonSimplePad.Properties.Resources.supprimer_icone_6859_16;
            this.simpleButton24.Location = new System.Drawing.Point(269, 12);
            this.simpleButton24.Name = "simpleButton24";
            this.simpleButton24.Size = new System.Drawing.Size(75, 23);
            this.simpleButton24.TabIndex = 13;
            this.simpleButton24.Text = "Supprimer";
            this.simpleButton24.Click += new System.EventHandler(this.simpleButton24_Click);
            // 
            // simpleButton23
            // 
            this.simpleButton23.Image = global::RibbonSimplePad.Properties.Resources.actualiser_16;
            this.simpleButton23.Location = new System.Drawing.Point(26, 12);
            this.simpleButton23.Name = "simpleButton23";
            this.simpleButton23.Size = new System.Drawing.Size(75, 23);
            this.simpleButton23.TabIndex = 14;
            this.simpleButton23.Text = "Actualiser";
            this.simpleButton23.Click += new System.EventHandler(this.simpleButton23_Click);
            // 
            // projets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 447);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "projets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Liste de Projets";
            this.Activated += new System.EventHandler(this.projets_Activated);
            this.Load += new System.EventHandler(this.projets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton9;
        private DevExpress.XtraEditors.SimpleButton simpleButton26;
        private DevExpress.XtraEditors.SimpleButton simpleButton25;
        private DevExpress.XtraEditors.SimpleButton simpleButton22;
        private DevExpress.XtraEditors.SimpleButton simpleButton24;
        private DevExpress.XtraEditors.SimpleButton simpleButton23;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}