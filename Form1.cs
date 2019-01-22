using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using RibbonSimplePad.Properties;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraBars.Alerter;
namespace RibbonSimplePad
{
    public partial class Form1 : RibbonForm
    {

        public static string idAlert, idButton;
      
      
        public static gestion_client gest_client = new gestion_client();
        public static calendrier call = new calendrier();
        public static retour_client rttt = new retour_client();
        public static user us = new user();
        public static about ab = new about();
        public static statistique st = new statistique();
        public static Historiqueprospectioncs hidto = new Historiqueprospectioncs();
        public static tomorrowprospectioncs tomprosp = new tomorrowprospectioncs();
     
        public static societe frm_societe = new societe();
        public static string etat_stat = "", deconn = "no";
        public static int wait = 0;
        public static WaitForm1 waitt = new WaitForm1();
        SplashScreenManager sp = new SplashScreenManager();
        sql_gmao fun = new sql_gmao();
        public static int load = 0;
        public static string des = "Déconnexion";

        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           



            //****************** gestion Stock****************************//

          
          
          

            ////********************** Admin *****************************//
         
            barStaticItem1.Caption = login1.nom + " " + login1.prenom;


          
           
            siStatus.Caption = System.DateTime.Now.ToLongDateString();
            siInfo.Caption = System.DateTime.Now.ToShortTimeString();
            deconn = "no";
            timer1.Start();

            if ( gest_client== null)
            { gest_client = new gestion_client(); }
            else { wait = 1; }

            gest_client.MdiParent = this;
            gest_client.Show();
            gest_client.BringToFront();
            fillprospnowadays();
            fillprosptomorrow();
          
            PrepareNotifcation();
            RunAlert();
        }
        private void fillprospnowadays()
        {
            DataTable dt = new DataTable();
            dt = fun.getallprospectbydate(System.DateTime.Today);
            foreach (DataRow dr in dt.Rows)
            {
               DataTable dtclient = fun.get_cltByCode(Convert.ToInt32(dr[1]));
               fun.insert_prospectionnowaday(Convert.ToInt32(dr[1]), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), Convert.ToDateTime(dr[5]), dtclient.Rows[0][7].ToString(), dtclient.Rows[0][3].ToString(), dtclient.Rows[0][10].ToString(), dtclient.Rows[0][14].ToString(), Convert.ToInt32(dr[0].ToString()),dtclient.Rows[0][15].ToString(),dtclient.Rows[0][16].ToString());
               

            }
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
                dt.Merge( fun.getallprospectbydatetomorrow(date1));
           

            }
            else 
            {
                DateTime date = DateTime.Today.AddDays(1);
                dt = fun.getallprospectbydatetomorrow(date);
            }
           
            foreach (DataRow dr in dt.Rows)
            {
                DataTable dtclient = fun.get_cltByCode(Convert.ToInt32(dr[1]));
                fun.insert_prospectiontomorrow(Convert.ToInt32(dr[1]), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), Convert.ToDateTime(dr[5]), dtclient.Rows[0][7].ToString(), dtclient.Rows[0][3].ToString(), dtclient.Rows[0][10].ToString(), dtclient.Rows[0][14].ToString(), Convert.ToInt32(dr[0].ToString()),dtclient.Rows[0][15].ToString(),dtclient.Rows[0][16].ToString());


            }
        }
        private void PrepareNotifcation()
        {
            DataTable prospect = new DataTable();
            prospect = fun.getallprospectbydatetomorrow();

          
           
        }
        private void AlertDesign()
        {
            Image ig = Properties.Resources.supprimer_icone_6859_16;
            AlertButton bt1 = new AlertButton(ig);
            bt1.Name = "hideAlert";
            bt1.Hint = "Ne pas afficher";
            bt1.Style = AlertButtonStyle.Button;
            alertControl1.Buttons.Add(bt1);
        }
        private void RunAlert()
        {

            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(RunAlert));
            }
            else
            {
                
                DataTable AllcmdAlert = new DataTable();
                AllcmdAlert= fun.getallprospectbydatetomorrow();
                if (AllcmdAlert.Rows.Count != 0)
                {
                    foreach (DataRow rowCMD in AllcmdAlert.Rows)
                    {
                       
                            Image anIm = Properties.Resources.info;
                            alertControl1.Show(this, new DevExpress.XtraBars.Alerter.AlertInfo(rowCMD[2].ToString() + " " + rowCMD[7].ToString(), rowCMD[5].ToString(), anIm));
                       
                    }

                }
            }

        }
      
       
        
        private void navBarGroup2_ItemChanged(object sender, EventArgs e)
        {
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            siStatus.Caption = System.DateTime.Now.ToLongDateString();
            siInfo.Caption = System.DateTime.Now.ToShortTimeString();
        }
        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }
      
        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }
      
        private void Stat1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }
        private void Stat2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string font = UserLookAndFeel.Default.SkinName.ToString();
            
            fun.update_skin(login1.id_user, font);
            if (deconn == "no")
            {
                XtraMessageBox.Show("Déconnectez vous", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            else
            {

               
                 DateTime histDate55 = DateTime.Now;

               // fun.t_estt(des.ToString(), login1.pseudo, histDate55.ToString());
                foreach (XtraForm frm in this.MdiChildren)
                {
                    frm.Close();
                }
                foreach (AlertForm form in alertControl1.AlertFormList)
                    form.Close();
                notifi.Stop();
            }
        }
        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            deconn = "yes";
            login1 log = new login1();
            log.Visible = true;
            this.Close();
            fun.removeallpr();
            fun.removeprtomorrow();
        }
        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }
       
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (wait == 1)
            {
                if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
                {
                    SplashScreenManager.CloseForm();
                }
                wait = 0;
                timer2.Stop();
            }
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }
        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (call == null)
            { call = new calendrier(); }
            else { wait = 1; }
            call.MdiParent = Form1.ActiveForm;
            call.Show();
            call.BringToFront();
        }
        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            ab = new about();
            ab.Show();
            us.TopMost = true;
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            us = new user();
            us.Show();
            us.TopMost = true;
        }

        private void alertControl1_AlertClick(object sender, AlertClickEventArgs e)
        {
           
        }

      

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (frm_societe == null)
            { frm_societe = new societe(); }
            else { wait = 1; }
            frm_societe.MdiParent = Form1.ActiveForm;
            frm_societe.Show();
            frm_societe.BringToFront();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void notifi_Tick(object sender, EventArgs e)
        {
            notifi.Start();
            PrepareNotifcation();
            RunAlert();
        }

       

        private void navBarItem10_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (gest_client == null)
            { gest_client = new gestion_client(); }
            else { wait = 1; }
            gest_client.MdiParent = Form1.ActiveForm;
            gest_client.Show();
            gest_client.BringToFront();
        }

        private void navBarItem19_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
          
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void Group_stock_ItemChanged(object sender, EventArgs e)
        {
           
        }

        private void nav_cde_feur_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void nav_gest_devis_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void nav_suivi_alime_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void nav_sort_stock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void nav_retour_clt_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (rttt == null)
            { rttt = new retour_client(); }
            else { wait = 1; }


            rttt.MdiParent = Form1.ActiveForm;
            rttt.Show();
            rttt.BringToFront();
        }

     
        private void navBarItem7_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (st == null)
            { st = new statistique(); }
            else { wait = 1; }
            st.MdiParent = Form1.ActiveForm;
            st.Show();
            st.BringToFront();
        }

        private void navBarItem9_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (hidto == null)
            { hidto = new Historiqueprospectioncs(); }
            else { wait = 1; }
            hidto.MdiParent = Form1.ActiveForm;
            hidto.Show();
            hidto.BringToFront();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            timer2.Start();
            if (SplashScreenManager.Default != null && SplashScreenManager.Default.IsSplashFormVisible)
            {
                SplashScreenManager.CloseForm();
            }
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            if (tomprosp == null)
            { tomprosp = new tomorrowprospectioncs(); }
            else { wait = 1; }
            tomprosp.MdiParent = Form1.ActiveForm;
            tomprosp.Show();
            tomprosp.BringToFront();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (AlertForm form in alertControl1.AlertFormList)
                form.Close();
            notifi.Stop();
        }
    }
}