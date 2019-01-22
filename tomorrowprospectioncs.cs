using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace RibbonSimplePad
{
    public partial class tomorrowprospectioncs : DevExpress.XtraEditors.XtraForm
    {
        sql_gmao fun = new sql_gmao();
        public tomorrowprospectioncs()
        {
            InitializeComponent();


            
        }
        private void fillgrid(DataTable prospects)
        {
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = prospects;
          gridView1.Columns[0].Visible=false;
          gridView1.Columns[1].Visible = false;
          gridView1.Columns[2].Caption = "Raison sociale";
          gridView1.Columns[3].Caption = "Date dernier prospection";
          gridView1.Columns[4].Caption = "Commentaire";
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
            dt = fun.getallprospectbydatetomorrow();

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

     

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            
        }

  

        private void tomorrowprospectioncs_Activated(object sender, EventArgs e)
        {
            fun.removeprtomorrow();
            fillprosptomorrow();
            DataTable dt = new DataTable();
            dt = fun.getallprospectbydatetomorrow();
            fillgrid(dt);        
        }
        private void fillprosptomorrow()
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            if (System.DateTime.Today.DayOfWeek.ToString() == "Saturday")
            {
                DateTime date = DateTime.Today.AddDays(1);
                dt = fun.getallprospectbydatetomorrow(date);
                DateTime date1 = DateTime.Today.AddDays(2);
                dt.Merge(fun.getallprospectbydatetomorrow(date1));


            }
            else
            {
                DateTime date = DateTime.Today.AddDays(1);
                dt = fun.getallprospectbydatetomorrow(date);
            }

            foreach (DataRow dr in dt.Rows)
            {
                DataTable dtclient = fun.get_cltByCode(Convert.ToInt32(dr[1]));
                fun.insert_prospectiontomorrow(Convert.ToInt32(dr[1]), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), Convert.ToDateTime(dr[5]), dtclient.Rows[0][7].ToString(), dtclient.Rows[0][3].ToString(), dtclient.Rows[0][10].ToString(), dtclient.Rows[0][14].ToString(), Convert.ToInt32(dr[0].ToString()), dtclient.Rows[0][15].ToString(), dtclient.Rows[0][16].ToString());


            }
        }
    

     
    }
}