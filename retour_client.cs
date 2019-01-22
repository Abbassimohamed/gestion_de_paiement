﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using System.Diagnostics;
using System.IO;


namespace RibbonSimplePad
{
    public partial class retour_client : DevExpress.XtraEditors.XtraForm
    {
        public retour_client()
        {
            InitializeComponent();
        }
        sql_gmao fun = new sql_gmao();
        public static string key, designation_is, contenue_is, etat_form = "", ActeurInterne, ActeurExterne, famille_eq, codeintervention;
        public static int id_is, idequ, idCompteur, idMesureInitiale;
        public static int? SfamillInitiale, famillInitiale;
        public static string oper, des, id_contrat_g, desc, cd_cont, GlobalCodeEq, look3, occupedMesure, CodeinterSurMesureInitiale, NominterSurMesureInitiale, NewMesureInter;
        public static int code_projet;
        public static int id_fich;
        public static string descri, clt, date, commentaire, total, direc;
        public static byte[] imm;
        private void retour_client_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            oper = "ajouter";
            retour_jointure co = new retour_jointure();
            co.ShowDialog();
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            oper = "modifier";
            System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            id_fich = Convert.ToInt32(row[0]);
            descri = row[1].ToString();
            clt = row[2].ToString();
            date = row[3].ToString();
            commentaire = row[4].ToString();
            total = row[8].ToString();
            direc = row[10].ToString();


            
            cd_cont = row[7].ToString();
            retour_jointure co = new retour_jointure();
            co.ShowDialog();
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
            id_fich = Convert.ToInt32(row[0]);
            fun.delete__pict(id_fich);
            getAllFichierContrat();
        }
        private void getAllFichierContrat()
        {
            gridControl5.DataSource = null;
            gridView5.Columns.Clear();
            string bbbb = "oui";
            if (login1.depart == "direction")
            {
               
                gridControl5.DataSource = fun.get_retour1(projets.id_projet); }
            else
            {
                gridControl5.DataSource = fun.get_retour1a(projets.id_projet, bbbb);
            
            }
            
            RepositoryItemPictureEdit pictureEdit = gridControl5.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            pictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;

            gridView5.Columns["extension"].ColumnEdit = pictureEdit;
            this.gridView5.Columns[0].Visible = false;
            this.gridView5.Columns[1].Caption = "Description";
            this.gridView5.Columns[2].Visible = false;
            this.gridView5.Columns[3].Caption = "Date de création";
            this.gridView5.Columns[4].Caption = "Commentaire";
            this.gridView5.Columns[6].Caption = "Type de fichier";
            this.gridView5.Columns[7].Visible = false;
            this.gridView5.Columns[8].Visible = false;
            this.gridView5.Columns[9].Visible = false;
            this.gridView5.Columns[10].Visible = false;

            gridView5.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView5.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
           
        }
        private void simpleButton23_Click(object sender, EventArgs e)
        {
            getAllFichierContrat();
            gridView5.BeginSort();

            try
            {

                gridView5.ClearSorting();



                gridView5.Columns["id"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            }

            finally
            {

                gridView5.EndSort();

            }
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            gridControl5.ShowRibbonPrintPreview();
        }

        private void retour_client_Activated(object sender, EventArgs e)
        {
            getAllFichierContrat();
            gridView5.OptionsView.ShowAutoFilterRow = true;
            gridView5.BestFitColumns();
            gridView5.OptionsBehavior.Editable = false;
            gridView5.OptionsView.EnableAppearanceEvenRow = true;
            Form1.load = 1;

            Form1.wait = 1;
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo celclick = gridView5.CalcHitInfo(gridControl5.PointToClient(Control.MousePosition));
            if (celclick.InRow)
            {
                int count = gridView5.DataRowCount;
                if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
                {
                    System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                    imm = DevExpress.XtraEditors.Controls.ByteImageConverter.ToByteArray(row[7]);
                    //des = row[4].ToString();
                    //id_fich = Convert.ToInt32(row[3]);
                    //System.Diagnostics.Process.Start(row[6].ToString());
                    //zz.ShowDialog();
                    byte[] bytes = imm;
                    string nom = row[1].ToString();
                    string extention = row[6].ToString();
                    string path2 = @"c:\STOCK\DOCS\";
                    //string path = @"c:\STOCK\DOCS\" + nom + extention;
                    string path = Path.Combine(path2, extention);

                    if (Directory.Exists(path2))
                    {
                        try
                        {
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                            {
                                writer.Write(bytes);
                            }

                            // open it with default application based in the
                            // file extension
                            Process p = System.Diagnostics.Process.Start(path);
                            //p.Wait();
                        }
                        finally
                        {
                            //clean the tmp file
                            //File.Delete(path);
                        }


                    }
                    else
                    {

                        System.IO.Directory.CreateDirectory(path2);
                        try
                        {
                            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                            {
                                writer.Write(bytes);
                            }

                            // open it with default application based in the
                            // file extension
                            Process p = System.Diagnostics.Process.Start(path);
                            //p.Wait();
                        }
                        finally
                        {
                            //clean the tmp file
                            //File.Delete(path);
                        }
                    }

                }
            }
        
        
        }

        private void retour_client_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            gridView5.BeginSort();

            try
            {

                gridView5.ClearSorting();



                gridView5.Columns["id"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            }

            finally
            {

                gridView5.EndSort();

            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int count = gridView5.DataRowCount;
            if (count != 0 && gridView5.FocusedRowHandle != DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                System.Data.DataRow row = gridView5.GetDataRow(gridView5.FocusedRowHandle);
                code_projet = Convert.ToInt32(row[0]);

                details dt = new details();
                dt.ShowDialog();
            }
        }
    }
}