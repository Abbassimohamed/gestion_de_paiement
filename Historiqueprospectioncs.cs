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
    public partial class Historiqueprospectioncs : DevExpress.XtraEditors.XtraForm
    {
        sql_gmao fun = new sql_gmao();
        public Historiqueprospectioncs()
        {
            InitializeComponent();


            
        }
        private void fillgrid(DataTable prospects)
        {
            RepositoryItemMemoEdit riCombo = new RepositoryItemMemoEdit();
            
            //Add a repository item to the repository items of grid control
            gridControl1.RepositoryItems.Add(riCombo);
            //Now you can define the repository item as an inplace editor of columns
           
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = prospects;
            gridView1.OptionsView.RowAutoHeight = true;
          gridView1.Columns[0].Visible=false;
          gridView1.Columns[1].Visible = false;
          gridView1.Columns[2].Caption = "Raison sociale";
          gridView1.Columns[3].Caption = "Date dernier prospection";
          gridView1.Columns[4].Caption = "Commentaire";
          gridView1.Columns[4].ColumnEdit = riCombo;   
          gridView1.Columns[5].Caption = "Date rappel";
          gridView1.Columns[6].Caption = "Ville";
          gridView1.Columns[7].Caption = "GSM";
          gridView1.Columns[8].Caption = "MF";
          gridView1.Columns[9].Caption = "Region";
          gridView1.Columns[10].Visible = false;
           
        }

        private void Historiqueprospectioncs_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = fun.getallprospectbydatenowaday();

            //List< ProspectionModel> prospections = new List< ProspectionModel>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ProspectionModel pr = new ProspectionModel();
            //    DataTable dtclient = new DataTable();
            //    dtclient = fun.get_cltByCode(Convert.ToInt32(dr[1]));

            //    pr.idclient=Convert.ToInt32( dr[1]);
            //    pr.raisonsoc=dr[2].ToString();
            //    pr.date =Convert.ToDateTime(dr[5]);
            //    pr.ville= dtclient.Rows[0][7].ToString();
            //    pr.numtel = dtclient.Rows[0][3].ToString();
            //    pr.matfisc = dtclient.Rows[0][10].ToString();
                
            //    prospections.Add(pr);
            
            //}
            fillgrid(dt);        
        }

     
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
               int count = gridView1.DataRowCount;
            if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                DataRow prospect =(DataRow) gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string client = prospect[2].ToString();
                int idclt =Convert.ToInt32( prospect[1]);
                DateTime date =Convert.ToDateTime( prospect[5]);
                int idprospect = Convert.ToInt32(prospect[10]);
                Newprospect newp = new Newprospect(idclt,client, date,idprospect);
                newp.ShowDialog();
            }
        
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                RepositoryItemMemoEdit riCombo = new RepositoryItemMemoEdit();

                //Add a repository item to the repository items of grid control
                gridControl1.RepositoryItems.Add(riCombo);
                //Now you can define the repository item as an inplace editor of columns
                DataTable dt = new DataTable();
                dt = fun.getallprospectbydatevalide(System.DateTime.Today);
                gridControl2.DataSource = null;
                gridView2.OptionsView.RowAutoHeight = true;
                gridView2.Columns.Clear();
                gridControl2.DataSource = dt;
                gridView2.OptionsView.RowAutoHeight = true;
                gridView2.Columns[0].Visible = false;
                gridView2.Columns[1].Visible = false;
                gridView2.Columns[2].Caption = "Client";
                gridView2.Columns[3].Caption = "Date prospection";
                gridView2.Columns[4].Caption = "Commentaire";
                gridView2.Columns[4].ColumnEdit = riCombo; 
                gridView2.Columns[5].Caption = "A rappeler le";
                gridView2.Columns[6].Visible = false;
            
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
              int count = gridView1.DataRowCount;
              if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
              {
                  DataRow drpr = (DataRow)gridView2.GetDataRow(gridView2.FocusedRowHandle);

                  string client = drpr[2].ToString();
                  int idclt =Convert.ToInt32( drpr[1].ToString());
                  DateTime datepro = Convert.ToDateTime(drpr[3]);
                  DateTime datrapp = Convert.ToDateTime(drpr[5]);
                  string comment = drpr[4].ToString();
                  int idprospect = Convert.ToInt32(drpr[0].ToString());
                  updateprospect newp = new updateprospect(idclt, client, datepro, comment, datrapp,idprospect);
                  newp.ShowDialog();
              }
        }

    

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            fun.removeallpr();
            fillprospnowadays();
            DataTable dt = new DataTable();
            dt = fun.getallprospectbydatenowaday();
            fillgrid(dt);

        }

        private void fillprospnowadays()
        {
            DataTable dt = new DataTable();
            dt = fun.getallprospectbydate(System.DateTime.Today);
            foreach (DataRow dr in dt.Rows)
            {
                DataTable dtclient = fun.get_cltByCode(Convert.ToInt32(dr[1]));
                fun.insert_prospectionnowaday(Convert.ToInt32(dr[1]), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), Convert.ToDateTime(dr[5]), dtclient.Rows[0][7].ToString(), dtclient.Rows[0][3].ToString(), dtclient.Rows[0][10].ToString(), dtclient.Rows[0][14].ToString(), Convert.ToInt32(dr[0].ToString()), dtclient.Rows[0][15].ToString(), dtclient.Rows[0][16].ToString());


            }
        }

        private void Historiqueprospectioncs_Activated(object sender, EventArgs e)
        {
            fun.removeallpr();
            fillprospnowadays();
            DataTable dt = new DataTable();
            dt = fun.getallprospectbydatenowaday();
            fillgrid(dt);
        }
     

     
    }
}