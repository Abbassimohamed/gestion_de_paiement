using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.Utils;
using System.Data.SqlClient;
using DevExpress.Utils.Animation;
namespace RibbonSimplePad
{
    public partial class statistique : DevExpress.XtraEditors.XtraForm
    {
        public statistique()
        {
            InitializeComponent();
        }
        sql_gmao fun = new sql_gmao();
        
        private void statistique_Load(object sender, EventArgs e)
        {

        }
        private void effect()
        {
            if (transitionManager1.Transitions[chartControl1] == null)
            {
                Transition transition1 = new Transition();
                transition1.Control = chartControl1;
                transitionManager1.Transitions.Add(transition1);
            }
            DevExpress.Utils.Animation.Transitions trType = (DevExpress.Utils.Animation.Transitions.Push);
            transitionManager1.Transitions[chartControl1].TransitionType = CreateTransitionInstance(trType);
            if (transitionManager1.IsTransaction)
            {
                transitionManager1.EndTransition();
            }
            transitionManager1.StartTransition(chartControl1);
            try
            {

            }
            finally
            {
                transitionManager1.EndTransition();
            }
        }
        BaseTransition CreateTransitionInstance(Transitions transitionType)
        {
            switch (transitionType)
            {
                case Transitions.Dissolve: return new DissolveTransition();
                case Transitions.Fade: return new FadeTransition();
                case Transitions.Shape: return new ShapeTransition();
                case Transitions.Clock: return new ClockTransition();
                case Transitions.SlideFade: return new SlideFadeTransition();
                case Transitions.Cover: return new CoverTransition();
                case Transitions.Comb: return new CombTransition();
                default: return new PushTransition();
            }
        }
        private void statistique_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void statistique_Activated(object sender, EventArgs e)
        {
            chartControl1.DataSource = null;
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();
            ChartTitle chartTitle1 = new ChartTitle();

            //*********************************** stat seuil stock ***********************************
            //string a, b, c, d, ee, f, g, h, i, j;
            //int a1, b1, c1, d1, ee1, f1, g1, h1, i1, j1;
            //a= "Annuaire";
            //b= "Bouche à oreille";
            //c= "Codeur";
            //d="Compagne emailing";
            //ee="Compagne smsing";
            //f="Facebook";
            //g="Foire";
            //h="Phoning";
            //i="Recherche internet";
            //j= "Autre";
            

            
            //DataTable daa, db, dc, dd, de, df, dg, dh, di, dj;
            //daa= fun.count_value(a);
          
            //db = fun.count_value(b);
            //dc = fun.count_value(c);
            //dd = fun.count_value(d);
            //de = fun.count_value(ee);
            //df = fun.count_value(f);
            //dg = fun.count_value(g);
            //dh = fun.count_value(h);
            //di = fun.count_value(i);
            //dj = fun.count_value(j);
            //a1 = Convert.ToInt32(daa.Rows[0][0]);
            //b1 = Convert.ToInt32(db.Rows[0][0]);
            //c1 = Convert.ToInt32(dc.Rows[0][0]);
            //d1 = Convert.ToInt32(dd.Rows[0][0]);
            //ee1 = Convert.ToInt32(de.Rows[0][0]);
            //f1 = Convert.ToInt32(df.Rows[0][0]);
            //g1 = Convert.ToInt32(dg.Rows[0][0]);
            //h1 = Convert.ToInt32(dh.Rows[0][0]);
            //i1 = Convert.ToInt32(di.Rows[0][0]);
            //j1 = Convert.ToInt32(dj.Rows[0][0]);


            //fun.update_stat(a1,a);
            //fun.update_stat(b1, b);
            //fun.update_stat(c1, c);
            //fun.update_stat(d1, d);
            //fun.update_stat(ee1, ee);
            //fun.update_stat(f1, f);
            //fun.update_stat(g1, g);
            //fun.update_stat(h1, h);
            //fun.update_stat(i1, i);
            //fun.update_stat(j1, j);
         


                SqlCommand selectCommand = new SqlCommand("SELECT * FROM client ");
                SqlDataAdapter da = new SqlDataAdapter(selectCommand);
                DataSet ds = new DataSet();
                selectCommand.Connection = sql_gmao.conn;
                da.Fill(ds, "client");
                Series series1 = new Series("source", ViewType.Bar);
                chartControl1.Series.Add(series1);
              
                chartControl1.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                chartControl1.DataSource = ds.Tables[0];
                chartControl1.Series[0].ArgumentDataMember = "source";
                chartControl1.Series[0].SummaryFunction = "COUNT()";
                ((BarSeriesView)series1.View).ColorEach = true;
                ((XYDiagram)chartControl1.Diagram).EnableAxisXZooming = true;
              
                chartTitle1.Text = "Source des Clients";

               
                chartControl1.Titles.Add(chartTitle1);
           
            rangeControl2.Dock = DockStyle.Top;
            chartControl1.Dock = DockStyle.Fill;
        }
    }
}