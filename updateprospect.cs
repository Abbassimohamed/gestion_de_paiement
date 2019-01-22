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
    public partial class updateprospect : DevExpress.XtraEditors.XtraForm
    {
        sql_gmao fun = new sql_gmao();
        public updateprospect(int idclt, string client, DateTime date,string comment,DateTime datrapp,int idprospect)
        {
            InitializeComponent();
            textEdit2.Text = idclt.ToString();
            textEdit1.Text = client;
            textEdit3.Text = idprospect.ToString();
            dateEdit1.DateTime = date;
            dateEdit2.DateTime = datrapp;
            memoEdit3.Text = comment;
           
        }
     
   
        private void labelControl30_Click(object sender, EventArgs e)
        {

        }

        private void memoEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Newprospect_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int idclt = Convert.ToInt32(textEdit3.Text);
                fun.update_prospectionall( memoEdit3.Text, dateEdit2.DateTime,idclt);             
                MessageBox.Show("Enregistrée avec succées");
                fillprospnowadays();
                this.Close();
            }
            catch (Exception exc)
            { }
        }
        private void fillprospnowadays()
        {
            DataTable dt = new DataTable();
           dt = fun.getallprospectbydatevalide(System.DateTime.Today);
            fillgrid(dt);
        }
        private void fillgrid(DataTable dt)
        {
            Historiqueprospectioncs hist=Form1.hidto;
           
            hist.gridControl2.DataSource = null;
            hist.gridView2.Columns.Clear();
            hist.gridControl2.DataSource = dt;
            hist.gridView2.Columns[0].Visible = false;
            hist.gridView2.Columns[1].Visible = false;
            hist.gridView2.Columns[2].Caption = "Client";
            hist.gridView2.Columns[3].Caption = "Date prospection";
            hist.gridView2.Columns[4].Caption = "Commentaire";
            hist.gridView2.Columns[5].Caption = "A rappeler le";
            hist.gridView2.Columns[6].Visible = false;
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Dispose();

         
        }
        public static void ClearAllForm(Control Ctrl)
        {
            foreach (Control ctrl in Ctrl.Controls)
            {
                BaseEdit editor = ctrl as BaseEdit;
                if (editor != null)
                    editor.EditValue = null;

                ClearAllForm(ctrl);//Recursive
            }

        }
    }
}