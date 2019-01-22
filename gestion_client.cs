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
    public partial class gestion_client : DevExpress.XtraEditors.XtraForm
    {
 
   
     sql_gmao fun = new sql_gmao();
     sql_gmao dd = new sql_gmao();
        public gestion_client()
        {
            InitializeComponent();
           
           
        }
        public static int code_clt;
        public static string clt;
      
        private void gestion_client_Load(object sender, EventArgs e)
        {
            xtraTabPage2.PageVisible = false;
            xtraTabPage3.PageVisible = false;
            gridView1.BestFitColumns();
            dateEdit1.DateTime = System.DateTime.Today;
            
            Listeclt();
           
          
        }

        private void gestion_client_Activated(object sender, EventArgs e)
        {
           
           
          
            Form1.load = 1;
            Form1.wait = 1;

            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;

            gridView1.BeginSort();

            try
            {

                gridView1.ClearSorting();



                gridView1.Columns["code_clt"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            }

            finally
            {

                gridView1.EndSort();

            }
        }

        private void Listeclt()
        {

            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = fun.get_Allclt();
            this.gridView1.Columns[0].Caption = "Code";
            this.gridView1.Columns[1].Caption = "Raison sociale";
            this.gridView1.Columns[2].Caption = "Nom Résponsable";
            this.gridView1.Columns[3].Caption = "GSM";
            this.gridView1.Columns[4].Caption = "Téléphone";
            this.gridView1.Columns[5].Visible = false;
            this.gridView1.Columns[6].Caption = "Adresse";
            this.gridView1.Columns[7].Caption = "Ville";
            this.gridView1.Columns[8].Caption = "Email";
            this.gridView1.Columns[9].Visible = false;
            this.gridView1.Columns[10].Visible = false;
            this.gridView1.Columns[11].Caption = "Nature";
            this.gridView1.Columns[12].Caption = "Commentaire";
            this.gridView1.Columns[13].Caption = "Source";
            
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
        }
        private void Listecltlookup()
        {
            lookUpEdit1.Properties.ValueMember = "code_clt";
            lookUpEdit1.Properties.DisplayMember = "raison_soc";
            lookUpEdit1.Properties.DataSource = fun.get_Allclt();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["code_clt"].Caption = "Code client";
            lookUpEdit1.Properties.Columns["raison_soc"].Caption = "Raison sociale";
            lookUpEdit1.Properties.Columns["responsbale"].Visible = false;
            lookUpEdit1.Properties.Columns["gsm_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["tel_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["fax_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["adresse_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["ville_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["email_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["site_clt"].Visible = false;
            lookUpEdit1.Properties.Columns["forme_juriduque"].Visible = false;
            lookUpEdit1.Properties.Columns["nature"].Visible = false;
            lookUpEdit1.Properties.Columns["commentaire"].Visible = false;
            lookUpEdit1.Properties.Columns["source"].Visible = false;
           
         
        }
        private void getcltByCode(int code)
        {
            DataTable feur = new DataTable();
            feur = fun.get_cltByCode(code);
            if (feur.Rows.Count != 0)
            {
                textEdit10.Text = feur.Rows[0]["code_clt"].ToString();
                textEdit9.Text = feur.Rows[0]["raison_soc"].ToString();
                textEdit8.Text = feur.Rows[0]["responsbale"].ToString();
                textEdit7.Text = feur.Rows[0]["gsm_clt"].ToString();
                textEdit6.Text = feur.Rows[0]["tel_clt"].ToString();
                textEdit5.Text = feur.Rows[0]["fax_clt"].ToString();
                textEdit4.Text = feur.Rows[0]["adresse_clt"].ToString();
               
                comboBoxEdit2.Text = feur.Rows[0]["ville_clt"].ToString();
                textEdit3.Text = feur.Rows[0]["email_clt"].ToString();
                textEdit2.Text = feur.Rows[0]["site_clt"].ToString();
                comboBoxEdit5.Text = feur.Rows[0]["source"].ToString();
              
                textEdit1.Text = feur.Rows[0]["forme_juriduque"].ToString();
                comboBoxEdit1.Text = feur.Rows[0]["nature"].ToString();
                memoEdit2.Text = feur.Rows[0]["commentaire"].ToString();
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(comboBoxEdit3, "Champ obligatoire");
            }
            else
            {
               
                   
                    dxErrorProvider1.Dispose();
                    fun.set_clt(textEdit21.Text,textEdit20.Text, textEdit19.Text, textEdit18.Text, textEdit17.Text, textEdit16.Text,comboBoxEdit6.Text,textEdit11.Text, textEdit14.Text,textEdit13.Text,textEdit24.Text,comboBoxEdit3.Text, memoEdit1.Text, comboBoxEdit4.Text,textEdit15.Text,textEdit22.Text );
                    labelControl51.Text = "Client ajouté avec succées";
                    labelControl51.Visible = true;
                    timer1.Start();
                    Listeclt();
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    xtraTabPage3.PageVisible = false;
            }
            comboBoxEdit6.Text = "----";
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xtraTabPage3.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            textEdit21.Text = "";
            textEdit20.Text = "";
            textEdit19.Text = "";
            textEdit18.Text = "";
            textEdit17.Text = "";
            textEdit16.Text = "";
            textEdit14.Text = "";
            textEdit13.Text = "";
            textEdit24.Text = "";
            memoEdit1.Text = "";
            memoEdit2.Text = "";
          
            comboBoxEdit3.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int count = gridView1.DataRowCount;
            if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                getcltByCode(Convert.ToInt32(row[0]));
            }
            xtraTabPage2.PageVisible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabPage2.PageVisible = false;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int count = gridView1.DataRowCount;
            if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                fun.delete_clt(Convert.ToInt32(row[0]));
            }
            Listeclt();
        }

        private void xtraTabControl1_Selected(object sender, DevExpress.XtraTab.TabPageEventArgs e)
        {
            Listeclt();
           
        
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textEdit9.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(textEdit8, "Champ obligatoire");
            }

           else if (comboBoxEdit1.Text== "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(comboBoxEdit1, "Champ obligatoire");
            }
            else
            {
                dxErrorProvider1.Dispose();
                fun.update_clt(textEdit9.Text, textEdit8.Text, textEdit7.Text, textEdit6.Text, textEdit5.Text, textEdit4.Text, comboBoxEdit2.Text, textEdit3.Text, textEdit2.Text, textEdit1.Text, comboBoxEdit1.Text, Convert.ToInt32(textEdit10.Text), memoEdit2.Text, comboBoxEdit5.Text,textEdit12.Text,textEdit25.Text,textEdit23.Text);
                labelControl29.Visible = true;
                timer1.Start();
                Listeclt();
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                xtraTabPage2.PageVisible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text += "a";
            if (label1.Text.ToString() == "10aaa")
            {
                labelControl29.Visible = false;
                labelControl51.Visible = false;
                label1.Text = "10";
                timer1.Stop();
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            xtraTabPage3.PageVisible = false;
        }

        private void gestion_client_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            gridView1.BeginSort();

            try
            {

                gridView1.ClearSorting();


                gridView1.Columns["code_clt"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            }

            finally
            {

                gridView1.EndSort();

            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int count = gridView1.DataRowCount;
            if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                code_clt = Convert.ToInt32(row[0]);
                clt = row[1].ToString();

                projets rt = new projets();
                rt.ShowDialog();
            }
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point pt = this.Location;
                pt.Offset(this.Left + e.X, this.Top + e.Y);
                popupMenu1.ShowPopup(this.barManager1, Control.MousePosition);
            }
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Listeclt();
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            DataRow client = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            xtraTabControl1.SelectedTabPage = xtraTabPage4;

            Listecltlookup();
            int codeclt = Convert.ToInt32(client[0].ToString());
            lookUpEdit1.EditValue = codeclt;
  
        }
        private void fillgrid2(DataTable dt)
        { 
            gridControl2.DataSource=null;
            gridView2.Columns.Clear();
            gridControl2.DataSource = dt;
            gridView2.Columns[0].Visible=false;
            gridView2.Columns[1].Visible = false;
            gridView2.Columns[2].Caption = "Client";
            gridView2.Columns[3].Caption = "Date prospection";
            gridView2.Columns[4].Caption = "Commentaire";
            gridView2.Columns[5].Caption = "A rappeler le";
            gridView2.Columns[6].Caption = "Etat";



        }
        private void fillgrid3(DataTable dt)
        {
            RepositoryItemMemoEdit riCombo = new RepositoryItemMemoEdit();

            //Add a repository item to the repository items of grid control
            gridControl3.RepositoryItems.Add(riCombo);
            gridControl3.DataSource = null;
            gridView3.OptionsView.RowAutoHeight = true;
            gridView3.Columns.Clear();
            gridControl3.DataSource = dt;
            gridView3.OptionsView.RowAutoHeight = true;
            gridView3.Columns[0].Visible = false;
            gridView3.Columns[1].Visible = false;
            gridView3.Columns[2].Caption = "Client";
            gridView3.Columns[3].Caption = "Date prospection";
            gridView3.Columns[4].Caption = "Commentaire";
            gridView3.Columns[4].ColumnEdit = riCombo;
            gridView3.Columns[5].Caption = "A rappeler le";
            gridView3.Columns[6].Visible = false;



        }
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            DataRowView drv=(DataRowView) lookUpEdit1.GetSelectedDataRow();
            DataRow dr=drv.Row;

            fun.insert_prospection(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), dateEdit1.DateTime, memoEdit3.Text, dateEdit2.DateTime,"non validé");
            MessageBox.Show("Ajoutée avec succées");

            DataTable dt = new DataTable();
            dt = fun.getallprospectbycient(Convert.ToInt32(dr[0].ToString()));
            fillgrid2(dt);
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
           
          
            if (xtraTabControl1.SelectedTabPage == xtraTabPage4)
                {

                    DataRow client = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                        Listecltlookup();
                        //int codeclt = Convert.ToInt32(client[0].ToString());
                        //lookUpEdit1.EditValue = codeclt;
                      
                }
            if (xtraTabControl1.SelectedTabPage == xtraTabPage5)
            {
                
                DataTable dt = new DataTable();
                dt = fun.getallprospect();


                fillgrid3(dt);
            
            }

         
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (memoEdit3.Text != null ||dateEdit2.DateTime!=null)
                {
                    memoEdit3.Text = "";
                    dateEdit2.EditValue = null;
                }
                
                DataRowView drv = (DataRowView)lookUpEdit1.GetSelectedDataRow();
                DataRow dr = drv.Row;
                int idclient = Convert.ToInt32(dr[0].ToString());
                DataTable dt = new DataTable();
                dt = fun.getallprospectbycient(idclient);        
                fillgrid2(dt);
            }
            catch (Exception exc)
            { }

        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount != 0 && gridView2.FocusedRowHandle != null)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                memoEdit3.Text = row[4].ToString();
                dateEdit1.DateTime = Convert.ToDateTime(row[3]);
                dateEdit2.DateTime = Convert.ToDateTime(row[5]);
                textEdit26.Text = row[0].ToString();
            }
        }

        private void textEdit21_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
           DataTable numeros = new DataTable();
            numeros = fun.get_Allclt();

            foreach (DataRow a in numeros.Rows)
            {
                collection.Add(a[1].ToString());
            }
            textEdit21.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textEdit21.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textEdit21.MaskBox.AutoCompleteCustomSource = collection;
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = fun.getallprospectbymonth(dateEdit3.DateTime.Month);
          
            fillgrid3(dt);
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = fun.getallprospect();


            fillgrid3(dt);
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {

           
                 int count = gridView3.DataRowCount;
            if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                DialogResult dialogResult = XtraMessageBox.Show("Sure de vouloir Annuler l'opération ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (int i in gridView3.GetSelectedRows() )
                    {
                        System.Data.DataRow row = gridView3.GetDataRow(i);
                        fun.delete_prospect(Convert.ToInt32(row[0]));
                    }

                }
               
            }
            DataTable dt = new DataTable();
            dt = fun.getallprospect();


            fillgrid3(dt);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)lookUpEdit1.GetSelectedDataRow();
                DataRow dr = drv.Row;

                fun.update_prospect(Convert.ToInt32(textEdit26.Text), dateEdit1.DateTime, memoEdit3.Text, dateEdit2.DateTime);
                DataTable dt = new DataTable();
                dt = fun.getallprospectbycient(Convert.ToInt32(dr[0]));
                fillgrid2(dt);
            }
            catch (Exception exc)
            { }
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = XtraMessageBox.Show("Sure de vouloir supprimer l'enregistrement ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {


                    fun.delete_prospect(Convert.ToInt32(textEdit26.Text));
                    DataRowView drv = (DataRowView)lookUpEdit1.GetSelectedDataRow();
                    DataRow dr = drv.Row;

                    DataTable dt = new DataTable();
                    dt = fun.getallprospectbycient(Convert.ToInt32(dr[0]));
                    fillgrid2(dt);


                }
            }
            catch (Exception exc)
            { }
        }

     
    }
}