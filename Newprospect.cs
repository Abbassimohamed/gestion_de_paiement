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
    public partial class Newprospect : DevExpress.XtraEditors.XtraForm
    {
        sql_gmao fun = new sql_gmao();
        public Newprospect(int idclt, string client,DateTime date,int idprospect)
        {
            InitializeComponent();
            textEdit2.Text = idclt.ToString();
            textEdit1.Text = client;
            dateEdit1.DateTime = date;
            textEdit3.Text = idprospect.ToString();
           
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
                fun.insert_prospection(Convert.ToInt32(textEdit2.Text), textEdit1.Text, dateEdit1.DateTime, memoEdit3.Text, dateEdit2.DateTime,"non validé");
                fun.update_prospection(Convert.ToInt32(textEdit3.Text), "validé");
                fun.removepr(Convert.ToInt32(textEdit3.Text));
                //fun.insert_prospectionjournalier(Convert.ToInt32(textEdit2.Text), textEdit1.Text, dateEdit1.DateTime, memoEdit3.Text, dateEdit2.DateTime);
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
            dt = fun.getallprospectbydatenowaday();
            fillgrid(dt);
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ClearAllForm(memoEdit3);

         
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
        private void fillgrid(DataTable prospects)
        {
            Historiqueprospectioncs hist = Form1.hidto;

            hist.gridControl1.DataSource = null;
            hist.gridView1.Columns.Clear();
            hist.gridControl1.DataSource = prospects;
            hist.gridView1.Columns[0].Visible = false;
            hist.gridView1.Columns[1].Visible = false;
            hist.gridView1.Columns[2].Caption = "Raison sociale";
            hist.gridView1.Columns[3].Caption = "Date dernier prospection";
            hist.gridView1.Columns[4].Caption = "Commentaire";
            hist.gridView1.Columns[5].Caption = "Date rappel";
            hist.gridView1.Columns[6].Caption = "Ville";
            hist.gridView1.Columns[7].Caption = "GSM";
            hist.gridView1.Columns[8].Caption = "MF";
            hist.gridView1.Columns[9].Caption = "Region";
            hist.gridView1.Columns[10].Visible = false;

        }
    }
}