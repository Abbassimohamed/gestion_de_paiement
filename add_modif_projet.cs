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
    public partial class add_modif_projet : DevExpress.XtraEditors.XtraForm
    {
        public add_modif_projet()
        {
            InitializeComponent();
        }
        sql_gmao fun = new sql_gmao();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
             if (textEdit1.Text == "")
            {
                dxErrorProvider1.Dispose();
                dxErrorProvider1.SetError(textEdit1, "Champ obligatoire");
            }
           
             else if (comboBoxEdit1.Text == "")
             {
                 dxErrorProvider1.Dispose();
                 dxErrorProvider1.SetError(comboBoxEdit1, "Champ obligatoire");
             }
             else
             {
                 if (projets.etat == "ajouter")
                 {
                     MessageBox.Show(""+gestion_client.code_clt);
                     int a = 0;
                     fun.insert_projet(textEdit1.Text,gestion_client.code_clt,comboBoxEdit1.Text,memoEdit1.Text,a);

                     
                 
                 
                 }

                 if (projets.etat == "modifier")
                 {
                     fun.update_projet(textEdit1.Text,comboBoxEdit1.Text, memoEdit1.Text, projets.id_projet);




                 }
                 this.Close();
             }
        }

        private void add_modif_projet_Load(object sender, EventArgs e)
        {
            if (projets.etat == "modifier")
            { textEdit1.Text = projets.intitu;
            comboBoxEdit1.Text = projets.faisab;
            memoEdit1.Text = projets.comm;
            }
        }

        private void add_modif_projet_Activated(object sender, EventArgs e)
        {
            
        }
     
        }
    }
