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
    public partial class add_modif_taches : DevExpress.XtraEditors.XtraForm
    {
        public add_modif_taches()
        {
            InitializeComponent();
        }

        sql_gmao fun = new sql_gmao();
        private void simpleButton4_Click(object sender, EventArgs e)
        {

            if (textEdit1.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(textEdit1, "Champ obligatoire");
            }

            else if (memoEdit2 .Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(memoEdit2, "Champ obligatoire");
            }

            else if (dateEdit1.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(dateEdit1, "Choisir date début");
            }
            else if (dateEdit2.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(dateEdit2, "Choisir date fin");
            }

            else if (comboBoxEdit1.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(comboBoxEdit1, "Champ obligatoire");
            }

            else
            {

                if (details.etat_tache == "ajouter")
                {
                    fun.insert_tache(textEdit1.Text, memoEdit1.Text, memoEdit2.Text, dateEdit1.DateTime, timeEdit1.Text, dateEdit2.DateTime, timeEdit2.Text, memoEdit3.Text, comboBoxEdit1.Text, projets.id_projet, Convert.ToInt32(trackBarControl1.EditValue));

                }
                if (details.etat_tache == "modifier")
                {
                    fun.update_tache(textEdit1.Text, memoEdit1.Text, memoEdit2.Text, dateEdit1.DateTime, timeEdit1.Text, dateEdit2.DateTime, timeEdit2.Text, memoEdit3.Text, comboBoxEdit1.Text, details.id_tache, Convert.ToInt32(trackBarControl1.EditValue));

                }

                this.Close();
            }

        }

        private void add_modif_taches_Load(object sender, EventArgs e)
        {
            if (details.etat_tache == "modifier")
            {
                
                DataTable dd = new DataTable();
                dd = fun.get_tache2(details.id_tache);
                textEdit1.Text = dd.Rows[0]["tache"].ToString();
                memoEdit1.Text = dd.Rows[0]["descri"].ToString();
                memoEdit2.Text = dd.Rows[0]["personn"].ToString();
                timeEdit1.EditValue = dd.Rows[0]["heure_deb"].ToString();
                timeEdit2.EditValue = dd.Rows[0]["heure_fin"].ToString();
                comboBoxEdit1.Text = dd.Rows[0]["etat"].ToString();
                memoEdit3.Text = dd.Rows[0]["remar"].ToString();
                if (!(dd.Rows[0]["date_deb"] is DBNull))
                {
                    DateTime aa;
                    aa = Convert.ToDateTime(dd.Rows[0]["date_deb"]);
                    dateEdit1.Text = aa.ToShortDateString();
                }
                if (!(dd.Rows[0]["date_fin"] is DBNull))
                {
                    DateTime bb;
                    bb = Convert.ToDateTime(dd.Rows[0]["date_fin"]);

                    dateEdit2.Text = bb.ToShortDateString();
                }
                if (!(dd.Rows[0]["avance"] is DBNull))
                {

                    trackBarControl1.EditValue = Convert.ToInt32(dd.Rows[0]["avance"]);

                    
                }   


            }
        }

        private void memoEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}