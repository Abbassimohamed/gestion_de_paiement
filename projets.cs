using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace RibbonSimplePad
{
    public partial class projets : DevExpress.XtraEditors.XtraForm
    {
        public projets()
        {
            InitializeComponent();
        }
        sql_gmao fun = new sql_gmao();
        public static string etat, intitu, faisab, comm;
        public static int id_projet,id_clt;
        private void simpleButton26_Click(object sender, EventArgs e)
        {
           
            add_modif_projet add = new add_modif_projet();
            etat = "ajouter";
            add.ShowDialog();
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            id_projet = Convert.ToInt32(row[0]);
            fun.delete__projet(id_projet);
            get_projet();
        }

        private void projets_Load(object sender, EventArgs e)
        {

        }
        private void get_projet()
        {
            gridControl5.DataSource = null;
            gridView5.Columns.Clear();
            gridControl5.DataSource = fun.get_projet(gestion_client.code_clt);

           
            RepositoryItemProgressBar progg = new RepositoryItemProgressBar();
          
            gridControl5.RepositoryItems.Add(progg);

            gridView5.Columns["av"].ColumnEdit = progg;
            progg.Step = 1;
            progg.PercentView = true;
            progg.Maximum = 10;
            progg.Minimum = 0;
            progg.ShowTitle = true;

            this.gridView5.Columns[0].Visible = false;
            this.gridView5.Columns[1].Caption = "Date de création";
            this.gridView5.Columns[2].Caption = "Intitulé";
            this.gridView5.Columns[3].Visible = false;
            this.gridView5.Columns[4].Visible = false;
            this.gridView5.Columns[5].Caption = "Faisabilité";
            this.gridView5.Columns[6].Caption = "Commentaire";
            this.gridView5.Columns[7].Caption = "Etat";
            this.gridView5.Columns[8].Visible = false;
            this.gridView5.Columns[9].Visible = false;
            this.gridView5.Columns[10].Visible = false;
            this.gridView5.Columns[11].Visible = false;
            this.gridView5.Columns[12].Visible = false;
            this.gridView5.Columns[13].Visible = false;
            this.gridView5.Columns[14].Visible = false;
            this.gridView5.Columns[15].Visible = false;
            this.gridView5.Columns[16].Visible = false;
            this.gridView5.Columns[17].Visible = false;
            this.gridView5.Columns[18].Caption = "Avancement";
            //gridView5.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gridView5.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            int count = gridView5.DataRowCount;
            if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                id_projet = Convert.ToInt32(row[0]);
                intitu = row["intitu"].ToString();
                faisab = row["faisab"].ToString();
                comm = row["comm"].ToString();
                etat = "modifier";
                add_modif_projet add = new add_modif_projet();
               
                add.ShowDialog();
            }
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            get_projet();
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            gridView5.ShowRibbonPrintPreview();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            gridView5.BeginSort();

            try
            {

                gridView5.ClearSorting();



                gridView5.Columns["id"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            }

            finally
            {

                gridView5.EndSort();

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             int count = gridView5.DataRowCount;
             if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
             {
                 System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                 id_projet = Convert.ToInt32(row[0]);

                 string etat = "En Négociation";
                 fun.update_etat_projet(id_projet, etat);
                 get_projet();
             }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             int count = gridView5.DataRowCount;
             if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
             {
                 System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                 id_projet = Convert.ToInt32(row[0]);

                 string etat = "En Attente";
                 fun.update_etat_projet(id_projet, etat);
                 get_projet();
             }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { int count = gridView5.DataRowCount;
        if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
        {
            System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            id_projet = Convert.ToInt32(row[0]);

            string etat = "Non Remporté";
            fun.update_etat_projet(id_projet, etat);
            get_projet();
        }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { int count = gridView5.DataRowCount;
        if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
        {
            System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            id_projet = Convert.ToInt32(row[0]);

            string etat = "Remporté";
            fun.update_etat_projet(id_projet, etat);
            get_projet();
        }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             int count = gridView5.DataRowCount;
             if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
             {
                 System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                 id_projet = Convert.ToInt32(row[0]);

                 details dd = new details();
                 dd.ShowDialog();
             }
        }

        private void gridControl5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point pt = this.Location;
                pt.Offset(this.Left + e.X, this.Top + e.Y);
                popupMenu1.ShowPopup(this.barManager1, Control.MousePosition);
            }
        }

        private void projets_Activated(object sender, EventArgs e)
        {
            get_projet();
        }
    }
}