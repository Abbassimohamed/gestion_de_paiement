using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace RibbonSimplePad
{
    public partial class details : DevExpress.XtraEditors.XtraForm
    {
        public details()
        {
            InitializeComponent();
        }
        sql_gmao fun = new sql_gmao();
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        public static string etat_tache;
        public static int id_tache;
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "En Pause")
            {
                stateIndicatorComponent2.Enabled = true; 
                stateIndicatorComponent2.StateIndex = 1;
            }
            if (comboBoxEdit1.Text == "En Travail")
            {
                stateIndicatorComponent2.Enabled = true;
                stateIndicatorComponent2.StateIndex = 2;
            }
            if (comboBoxEdit1.Text == "Cloturé")
            {
                stateIndicatorComponent2.Enabled = true;
                stateIndicatorComponent2.StateIndex = 3;
            }
            
        }

        private void textEdit6_Enter(object sender, EventArgs e)
        {
              }

        private void textEdit6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                memoEdit4.Text +=System.DateTime.Now.ToShortDateString() +" "+ System.DateTime.Now.ToShortTimeString() + " : [" + login1.pseudo + "] " + textEdit6.Text+Environment.NewLine;
                textEdit6.Text = "";
                fun.update_projet5(memoEdit4.Text, projets.id_projet);
            }
        }

        private void details_Load(object sender, EventArgs e)
        {
            if (login1.depart == "direction")
            { textEdit7.Visible = true;
            textEdit8.Visible = true;
            textEdit9.Visible = true;
            labelControl12.Visible = true;
            labelControl11.Visible = true;
            labelControl13.Visible = true;
                
            }
            else
            {
                textEdit7.Visible = false;
                textEdit8.Visible = false;
                textEdit9.Visible = false;
                labelControl12.Visible = false;
                labelControl11.Visible = false;
                labelControl13.Visible = false;

            }
              
          
        }
        private void get_taches()
        {
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = fun.get_tache(projets.id_projet);
            RepositoryItemProgressBar progg = new RepositoryItemProgressBar();

            gridControl1.RepositoryItems.Add(progg);

            gridView1.Columns["avance"].ColumnEdit = progg;
            progg.Step = 1;
            progg.PercentView = true;
            progg.Maximum = 10;
            progg.Minimum = 0;
            progg.ShowTitle = true;

            this.gridView1.Columns[0].Visible = false;
            this.gridView1.Columns[1].Caption = "Tâche";
            this.gridView1.Columns[2].Caption = "Description";
            this.gridView1.Columns[3].Caption = "Personne(s) chargée(s)";
            this.gridView1.Columns[4].Caption = "Date Debut";
            this.gridView1.Columns[5].Visible = false;
            this.gridView1.Columns[6].Caption = "Date Fin";
            this.gridView1.Columns[7].Visible = false;
            this.gridView1.Columns[8].Visible = false;
            this.gridView1.Columns[9].Caption = "Etat";
            this.gridView1.Columns[10].Visible = false;
            this.gridView1.Columns[11].Caption = "Avancement";

            //gridView5.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //gridView5.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            fun.update_projet2(textEdit2.Text, memoEdit1.Text, textEdit9.Text, textEdit8.Text,textEdit7.Text,projets.id_projet);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            fun.update_projet3(dateEdit2.DateTime,dateEdit3.DateTime,memoEdit2.Text,memoEdit3.Text,comboBoxEdit1.Text,projets.id_projet );
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dateEdit1.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(dateEdit1, "choisir une date");
            }
            else if (memoEdit5.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(memoEdit5, "Saisir la réclamation client");
            }
            else
            {
                memoEdit6.Text += "[ "+dateEdit1.Text +" ] " + memoEdit5.Text + Environment.NewLine;
                memoEdit5.Text = "";
                fun.update_projet4(memoEdit6.Text,projets.id_projet);
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            etat_tache = "ajouter";
            add_modif_taches aa = new add_modif_taches();
            aa.ShowDialog();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            etat_tache = "modifier";
            int count = gridView1.DataRowCount;
            if (count != 0 && gridView1.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                 id_tache= Convert.ToInt32(row[0]);

                 add_modif_taches aa = new add_modif_taches();
                 aa.ShowDialog();
            }
           
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            System.Data.DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            id_tache = Convert.ToInt32(row[0]);
            fun.delete__tache(id_tache);
            get_taches();
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            fun.update_projet_av(projets.id_projet, Convert.ToInt32(trackBarControl1.EditValue));
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            get_taches();
        }

        private void details_Activated(object sender, EventArgs e)
        {

            DataTable tt = new DataTable();
            tt = fun.affiche_projet(projets.id_projet);
            DateTime aa, bb, cc;
            cc = Convert.ToDateTime(tt.Rows[0]["datee"]);
            textEdit1.Text = cc.ToShortDateString();
            textEdit2.Text = tt.Rows[0]["intitu"].ToString();
            textEdit3.Text = gestion_client.clt;
            memoEdit1.Text = tt.Rows[0]["comm"].ToString();
            textEdit9.Text = tt.Rows[0]["net"].ToString();
            textEdit8.Text = tt.Rows[0]["avance"].ToString();
            textEdit7.Text = tt.Rows[0]["reste"].ToString();
            if (!(tt.Rows[0]["date_deb"] is DBNull))
            {
                aa = Convert.ToDateTime(tt.Rows[0]["date_deb"]);
                dateEdit2.Text = aa.ToShortDateString();
            }
            if (!(tt.Rows[0]["date_fin"] is DBNull))
            {
                bb = Convert.ToDateTime(tt.Rows[0]["date_fin"]);

                dateEdit3.Text = bb.ToShortDateString();
            }


            memoEdit2.Text = tt.Rows[0]["equipe_charge"].ToString();
            memoEdit3.Text = tt.Rows[0]["techno"].ToString();
            memoEdit4.Text = tt.Rows[0]["discuss"].ToString();
            comboBoxEdit1.Text = tt.Rows[0]["etat2"].ToString();
            memoEdit6.Text = tt.Rows[0]["rec"].ToString();
            if (tt.Rows[0]["etat"].ToString() == "En Négociation")
            { labelControl19.Visible = true; }
            if (tt.Rows[0]["etat"].ToString() == "En Attente")
            { labelControl20.Visible = true; }
            if (tt.Rows[0]["etat"].ToString() == "Non Remporté")
            { labelControl21.Visible = true; }
            if (tt.Rows[0]["etat"].ToString() == "Remporté")
            { labelControl22.Visible = true; }
            trackBarControl1.EditValue = Convert.ToInt32(tt.Rows[0]["av"]);
            if (comboBoxEdit1.Text == "")
            { stateIndicatorComponent2.Enabled = false; }
            
            get_taches();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            gridControl1.ShowRibbonPrintPreview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            retour_client rr = new retour_client();
            rr.ShowDialog();
        }
    }
}