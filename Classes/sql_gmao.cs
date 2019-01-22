using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace RibbonSimplePad
{
    class sql_gmao
    {
        public static string test_con, etat_euip;
        public SqlDataReader dr;
        public SqlDataAdapter da;

        public static string strconnection = "Data Source= .\\SQLR2;Initial Catalog=click2web;Integrated Security=True";
        //public static string strconnection = "Server= .\\SQLEXPRESS;Database=click2web;user ID=imen; password=imen";

        public static SqlConnection conn = new SqlConnection(strconnection);

        public string return_ch()
        {
            return strconnection;
        }
        public string strcon()
        {
            return strconnection;
        }
        public void connexion()
        {
            conn.Open();
            test_con = "true";

        }
        //fermeture de la connexion à la base des donnees
        public void closecon()
        {
            conn.Close();
            test_con = "false";
        }
        public void function_test()
        {
           
            if (conn.State.ToString().Equals("Open"))
            {
                conn.Close(); 
            }
            if (conn.State.ToString().Equals("Closed"))
            {
                conn.Open(); 
            }

        }
        public Boolean test_connexion()
        {
            if (test_con == "true")
                return (true);
            else
                return (false);

        }
        public DataTable DataReturn(string rq)
        {
            DataSet ds = new DataSet();
            DataTable data = new DataTable();
            ds.Reset();
            data.Reset();
            da = new SqlDataAdapter(rq, conn);
            da.Fill(ds, "table");
            data = ds.Tables["table"];
            return data;
        }
        public string DataExcute(string rq)
        {
            try
            {
                string req = rq;
                SqlCommand cmd = new SqlCommand(req, conn);
                cmd.ExecuteNonQuery();
                return "true";
            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        //*********************************** INSERT ***********************************
        //Suivi des actions effectuée par chaque utilisateur (log)
       


       
   
        //ajouter un fichier du contrat
        public string insert_retour(string des, int clt, string dat, string comm, byte[] imm, string type, byte[] c, string total, int code_clt )
        {
            function_test();
            try
            {
                string req = " insert into retour (descri, client, datee, commentaire, extension, type, imagee, total, clt) values (@descri, @client, @datee, @commentaire, @extension, @type, @imagee, @total, @clt)";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


                cmd.Parameters.Add(new SqlParameter("@descri", (object)des.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@client", (object)clt));
                cmd.Parameters.Add(new SqlParameter("@datee", (object)dat));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@extension", (object)imm));
                cmd.Parameters.Add(new SqlParameter("@type", (object)type));
                cmd.Parameters.Add(new SqlParameter("@imagee", (object)c));
                cmd.Parameters.Add(new SqlParameter("@clt", (object)code_clt));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total.Replace("'", "''")));
            
                cmd.ExecuteNonQuery();

                return "true";

               
            
            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string update_prospection(int idprospect, string etat)
        {
            function_test();
            try
            {
                string req = " update  prospection set etat=@etat where idprospection=@idprospection";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


          
                cmd.Parameters.Add(new SqlParameter("@etat", (object)etat));
                cmd.Parameters.Add(new SqlParameter("@idprospection", (object)idprospect));


                cmd.ExecuteNonQuery();

                return "true";



            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string update_prospectionall(string comm, DateTime daterappel,int idprosp)
        {
            function_test();
            try
            {
                string req = " update  prospection set  commentaire=@commentaire, daterappel=@daterappel where idprospection=@idprospection";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);

                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm));
                cmd.Parameters.Add(new SqlParameter("@daterappel", (object)daterappel));
                cmd.Parameters.Add(new SqlParameter("@idprospection", (object)idprosp));
              
                cmd.ExecuteNonQuery();

                return "true";



            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string insert_prospection(int idclient, string clt, DateTime datprospect, string comm, DateTime daterappel,string etat)
        {
            function_test();
            try
            {
                string req = " insert into prospection (idclient, nomclient, dateprospection, commentaire, daterappel,etat) values (@idclient, @nomclient, @dateprospection, @commentaire, @daterappel,@etat)";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


                cmd.Parameters.Add(new SqlParameter("@idclient", (object)idclient));
                cmd.Parameters.Add(new SqlParameter("@nomclient", (object)clt));
                cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)datprospect));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm));
                cmd.Parameters.Add(new SqlParameter("@daterappel", (object)daterappel));
                cmd.Parameters.Add(new SqlParameter("@etat", (object)etat));
             

                cmd.ExecuteNonQuery();

                return "true";



            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string insert_prospectionnowaday(int idclient, string clt, DateTime datprospect, string comm, DateTime daterappel,string ville,string numtel,string matfisc,string region,int numprospect,string secteur,string effectif)
        {
            function_test();
            try
            {
                string req = " insert into prospectionnowaday (idclient, nomclient, dateprospection, commentaire, daterappel,ville,numtel,matfisc,region,idprospectprevious,secteur,effectif) values (@idclient, @nomclient, @dateprospection, @commentaire, @daterappel,@ville,@numtel,@matfisc,@region,@idprospectprevious,@secteur,@effectif)";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


                cmd.Parameters.Add(new SqlParameter("@idclient", (object)idclient));
                cmd.Parameters.Add(new SqlParameter("@nomclient", (object)clt));
                cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)datprospect));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm));
                cmd.Parameters.Add(new SqlParameter("@daterappel", (object)daterappel));
                cmd.Parameters.Add(new SqlParameter("@ville", (object)ville));
                cmd.Parameters.Add(new SqlParameter("@numtel", (object)numtel));
                cmd.Parameters.Add(new SqlParameter("@matfisc", (object)matfisc));
                cmd.Parameters.Add(new SqlParameter("@region", (object)region));
                cmd.Parameters.Add(new SqlParameter("@idprospectprevious", (object)numprospect));
                cmd.Parameters.Add(new SqlParameter("@secteur", (object)secteur));
                cmd.Parameters.Add(new SqlParameter("@effectif", (object)effectif));



                cmd.ExecuteNonQuery();

                return "true";

            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string insert_prospectiontomorrow(int idclient, string clt, DateTime datprospect, string comm, DateTime daterappel, string ville, string numtel, string matfisc, string region, int numprospect,string secteur,string effectif)
        {
            function_test();
            try
            {
                string req = " insert into prospectiontomorrow (idclient, nomclient, dateprospection, commentaire, daterappel,ville,numtel,matfisc,region,idprospectprevious,secteur,effectif) values (@idclient, @nomclient, @dateprospection, @commentaire, @daterappel,@ville,@numtel,@matfisc,@region,@idprospectprevious,@secteur,@effectif)";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


                cmd.Parameters.Add(new SqlParameter("@idclient", (object)idclient));
                cmd.Parameters.Add(new SqlParameter("@nomclient", (object)clt));
                cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)datprospect));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm));
                cmd.Parameters.Add(new SqlParameter("@daterappel", (object)daterappel));
                cmd.Parameters.Add(new SqlParameter("@ville", (object)ville));
                cmd.Parameters.Add(new SqlParameter("@numtel", (object)numtel));
                cmd.Parameters.Add(new SqlParameter("@matfisc", (object)matfisc));
                cmd.Parameters.Add(new SqlParameter("@region", (object)region));
                cmd.Parameters.Add(new SqlParameter("@idprospectprevious", (object)numprospect));

                cmd.Parameters.Add(new SqlParameter("@secteur", (object)secteur));
                cmd.Parameters.Add(new SqlParameter("@effectif", (object)effectif));

                cmd.ExecuteNonQuery();

                return "true";

            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string insert_prospectionjournalier(int idclient, string clt, DateTime datprospect, string comm, DateTime daterappel)
        {
            function_test();
            try
            {
                string req = " insert into prospectionjournalier (idclient, nomclient, dateprospection, commentaire, daterappel) values (@idclient, @nomclient, @dateprospection, @commentaire, @daterappel)";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


                cmd.Parameters.Add(new SqlParameter("@idclient", (object)idclient));
                cmd.Parameters.Add(new SqlParameter("@nomclient", (object)clt));
                cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)datprospect));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm));
                cmd.Parameters.Add(new SqlParameter("@daterappel", (object)daterappel));


                cmd.ExecuteNonQuery();

                return "true";



            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }
        public string insert_retoura(string des, int clt, string dat, string comm, byte[] imm, string type, byte[] c, string total, int code_clt, string direc)
        {
            function_test();
            try
            {
                string req = " insert into retour (descri, client, datee, commentaire, extension, type, imagee, total, clt, direc) values (@descri, @client, @datee, @commentaire, @extension, @type, @imagee, @total, @clt, @direc)";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);


                cmd.Parameters.Add(new SqlParameter("@descri", (object)des.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@client", (object)clt));
                cmd.Parameters.Add(new SqlParameter("@datee", (object)dat));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@extension", (object)imm));
                cmd.Parameters.Add(new SqlParameter("@type", (object)type));
                cmd.Parameters.Add(new SqlParameter("@imagee", (object)c));
                cmd.Parameters.Add(new SqlParameter("@clt", (object)code_clt));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@direc", (object)direc));

                cmd.ExecuteNonQuery();

                return "true";



            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }




        public string set_clt(string raison_soc, string responsbale, string gsm_feur, string tel_feur, string fax_feur, string adresse_feur, string ville_feur,string region, string email_feur, string site_feur, string forme_juriduque, string nature, string commentaire, string source,string secteur,string effectif)
        {
            function_test();
            string req = "INSERT INTO client (raison_soc,responsbale,gsm_clt,tel_clt,fax_clt,adresse_clt,ville_clt,region,email_clt,site_clt,forme_juriduque,nature, commentaire, source,secteur,effectif) VALUES('" + raison_soc.Replace("'", "''") + "','" + responsbale.Replace("'", "''") + "','" + gsm_feur + "','" + tel_feur + "','" + fax_feur + "','" + adresse_feur.Replace("'", "''") + "','" + ville_feur.Replace("'", "''") + "','"+ region.Replace("'", "''") +"','" + email_feur.Replace("'", "''") + "','" + site_feur.Replace("'", "''") + "','" + forme_juriduque.Replace("'", "''") + "','" + nature + "', '" + commentaire.Replace("'", "''") + "', '" + source.Replace("'", "''") + "','"+secteur.Replace("'", "''")+"','"+effectif.Replace("'", "''")+"' )";
           return DataExcute(req);
        }



      
        //ajouter utilisateur de type gestion de stock
        public string insert_user_gestion_stock(string x1, string x2, string x3, string x4, string x5, string x6, string x7, string x8, string x9, string x10, string x11, string x12, string x13, string x14, string x15, string x16, string x17, string x18, string x19, string x20, string x21, string x22, string x23, string x24, string x25, string x26, string x27, string x28, string x29, string x30, string x31, string x32, string x33, string x34, string x35, string x36, string x37, string x38, string x39, string x40, string x41, string x42)
        {
            function_test();
            string req = "insert into droit (nom, prenom, fonction, depart, gsm, email, login, passwd, visualiser_stock, ajouter_stock, modifier_stock, supprimer_stock, ges_uni, ges_mag, doc_stock, passer_cde, aliment, sortie_prod, alim, sortie_sto, vis_clt, ajout_clt, mod_clt, supp_clt, doc_clt, supp_cde_clt, vali_cde_clt, fact, bon_liv, bon_sortie, vis_feur, aj_feur, mod_feur, supp_feur, doc_feur, supp_cde_feur, vis_dev, aj_devis, supp_dev, doc_dev, stat, noti)values('" + x1 + "','" + x2 + "','" + x3 + "', '" + x4 + "','" + x5 + "','" + x6 + "', '" + x7 + "','" + x8 + "','" + x9 + "', '" + x10 + "','" + x11 + "','" + x12 + "', '" + x13 + "','" + x14 + "','" + x15 + "','" + x16 + "', '" + x17 + "','" + x18 + "','" + x19 + "', '" + x20 + "','" + x21 + "','" + x22 + "', '" + x23 + "' , '" + x24 + "','" + x25 + "','" + x26 + "', '" + x27 + "' , '" + x28 + "', '" + x29 + "' , '" + x30 + "','" + x31 + "','" + x32 + "', '" + x33 + "' , '" + x34 + "', '" + x35 + "' , '" + x36 + "','" + x37 + "','" + x38 + "', '" + x39 + "' , '" + x40 + "', '" + x41 + "' , '" + x42 + "')";
         
            return DataExcute(req);
        }
        // ajouter une unité


        public string insert_projet(string intitu, int code_clt, string faisab, string comm, int a )
        {
            function_test();
            string req = "insert into projet (datee, intitu,  id_clt, faisab, comm, av) values ('" + System.DateTime.Today + "','" + intitu + "', '" + code_clt + "','" + faisab + "','" + comm + "', '"+a+"')";

            return DataExcute(req);
        }

        public string insert_tache(string tache, string desc, string personn , DateTime date_deb, string heure_deb, DateTime date_fin, string heure_fin, string remar, string etat, int id_projet, int avance)
        {
            function_test();
            string req = "insert into tache (tache, descri,  personn, date_deb, heure_deb, date_fin, heure_fin, remar, etat, id_projet, avance )values('" + tache.Replace("'", "''") + "','" + desc.Replace("'", "''") + "', '" + personn.Replace("'", "''") + "','" + date_deb + "','" + heure_deb + "' ,'" + date_fin + "' ,'" + heure_fin + "' ,'" + remar.Replace("'", "''") + "' ,'" + etat + "' ,'" + id_projet + "' ,'" + avance + "')";

            return DataExcute(req);
        }
       

        //ajouter utilisateur de type admin
        public string insert_user_admin(string x1, string x2, string x3, string x4, string x5, string x6, string x7, string x8)
        {
            function_test();
            string req = "insert into droit (nom, prenom, fonction, depart, gsm, email, login, passwd) values ('" + x1 + "','" + x2 + "','" + x3 + "', '" + x4 + "','" + x5 + "','" + x6 + "', '" + x7 + "','" + x8 + "')";
        
            return DataExcute(req);
        }
      
        public string set_administrateur(string nom, string poste, string dep, string gsm, string email, string login, string pwd)
        {
            function_test();
            string req = "INSERT INTO droit (n_p,fonction,depart,gsm,email,login,passwd) VALUES ('" + nom + "','" + poste + "','" + dep + "','" + gsm + "','" + email + "','" + login + "','" + pwd + "')";
           
            return DataExcute(req);
        }
       

       

        public string update_contrat_fich3(string a, string b, string c, string d, Byte[] e, string f, Byte[] g, int code, string total)
        {
            function_test();
            try
            {
                string req = " UPDATE retour set descri= @descri, datee= @datee, commentaire= @commentaire , extension= @extension, type= @type, imagee= @imagee , total= @total where id = @id";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);

                cmd.Parameters.Add(new SqlParameter("@id", (object)code));
                cmd.Parameters.Add(new SqlParameter("@descri", (object)a.Replace("'", "''")));
             
                cmd.Parameters.Add(new SqlParameter("@datee", (object)c));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)d.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@extension", (object)e));
                cmd.Parameters.Add(new SqlParameter("@type", (object)f));
                cmd.Parameters.Add(new SqlParameter("@imagee", (object)g));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total.Replace("'", "''")));
                cmd.ExecuteNonQuery();

                return "true";

                
            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }



        public string update_contrat_fich3a(string a, string b, string c, string d, Byte[] e, string f, Byte[] g, int code, string total, string direc)
        {
            function_test();
            try
            {
                string req = " UPDATE retour set descri= @descri, datee= @datee, commentaire= @commentaire , extension= @extension, type= @type, imagee= @imagee , total= @total, direc= @direc where id = @id";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);

                cmd.Parameters.Add(new SqlParameter("@id", (object)code));
                cmd.Parameters.Add(new SqlParameter("@descri", (object)a.Replace("'", "''")));

                cmd.Parameters.Add(new SqlParameter("@datee", (object)c));
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)d.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@extension", (object)e));
                cmd.Parameters.Add(new SqlParameter("@type", (object)f));
                cmd.Parameters.Add(new SqlParameter("@imagee", (object)g));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@direc", (object)direc));
                cmd.ExecuteNonQuery();

                return "true";


            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }

        public string update_contrat_ficheeeee(string a, string d, int code, string total)
        {
            function_test();
            try
            {
                string req = " UPDATE retour set descri= @descri, commentaire= @commentaire, total= @total where id = @id";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);

                cmd.Parameters.Add(new SqlParameter("@id", (object)code));
                cmd.Parameters.Add(new SqlParameter("@descri", (object)a.Replace("'", "''")));
                
                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)d.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total.Replace("'", "''")));
               
                cmd.ExecuteNonQuery();
               
            

                return "true";
            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }


        public string update_contrat_ficheeeeea(string a, string d, int code, string total, string direc)
        {
            function_test();
            try
            {
                string req = " UPDATE retour set descri= @descri, commentaire= @commentaire, total= @total , direc= @direc where id = @id";
                SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);

                cmd.Parameters.Add(new SqlParameter("@id", (object)code));
                cmd.Parameters.Add(new SqlParameter("@descri", (object)a.Replace("'", "''")));

                cmd.Parameters.Add(new SqlParameter("@commentaire", (object)d.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@total", (object)total.Replace("'", "''")));
                cmd.Parameters.Add(new SqlParameter("@direc", (object)direc));

                cmd.ExecuteNonQuery();



                return "true";
            }
            catch (Exception ss)
            {
                return (ss.Message);
            }
        }

        public string update_etat_projet(int code, string etat)
        {

            function_test();
            string req = "UPDATE projet SET etat ='" + etat + "'  WHERE id ='" + code + "'";

            return DataExcute(req);
        }

        public string update_stat(int code, string source)
        {

            function_test();
            string req = "UPDATE stat SET nbr ='" + code + "'  WHERE source ='" + source + "'";

            return DataExcute(req);
        }

        public string update_app_user(string user,int id)
        {

            function_test();
            string req = "UPDATE Appointments SET userr ='" + user + "'  WHERE UniqueID ='" + id + "'";

            return DataExcute(req);
        }


      
     

        public string update_clt(string raison, string respon, string gsm, string tel, string fax, string adr, string ville, string email, string site, string matrFisc, string nature, int code, string commentaire, string source,string region,string secteur,string effectif)
        {
           
            function_test();
            string req = "UPDATE client SET raison_soc ='" + raison.Replace("'", "''") + "' ,responsbale ='" + respon.Replace("'", "''") + "' ,gsm_clt ='" + gsm + "' ,tel_clt ='" + tel + "' ,fax_clt ='" + fax + "' ,adresse_clt ='" + adr.Replace("'", "''") + "' ,ville_clt ='" + ville.Replace("'", "''") + "',region ='" + region.Replace("'", "''")+"',email_clt ='" + email.Replace("'", "''") + "' ,site_clt ='" + site.Replace("'", "''") + "' ,forme_juriduque ='" + matrFisc.Replace("'", "''") + "' ,nature ='" + nature + "', commentaire ='" + commentaire.Replace("'", "''") + "', source ='" + source.Replace("'", "''") + "',secteur='"+secteur.Replace("'", "''")+"',effectif='"+effectif.Replace("'", "''") +"'  WHERE code_clt ='" + code + "'";
           
            return DataExcute(req);
        }


        public string update_projet(string intitu, string faisab, string comm, int code)
        {

            function_test();
            string req = "UPDATE projet SET intitu ='" + intitu.Replace("'", "''") + "' ,faisab ='" + faisab + "' ,comm ='" + comm.Replace("'", "''") + "' where id= '" + code + "'";

            return DataExcute(req);
        }

        public string update_projet_av(int id, int av)
        {

            function_test();
            string req = "UPDATE projet SET av ='" + av + "' where id= '" + id + "'";

            return DataExcute(req);
        }

        public string update_tache(string tache, string desc, string personn, DateTime date_deb, string heure_deb, DateTime date_fin, string heure_fin, string remar, string etat, int id_tache, int avance)
        {

            function_test();
            string req = "UPDATE tache SET tache ='" + tache.Replace("'", "''") + "' ,descri ='" + desc.Replace("'", "''") + "' ,personn ='" + personn.Replace("'", "''") + "' ,date_deb ='" + date_deb + "',heure_deb ='" + heure_deb + "' ,date_fin ='" + date_fin + "',heure_fin ='" + heure_fin + "' ,remar ='" + remar.Replace("'", "''") + "' ,etat ='" + etat + "' ,avance ='" + avance+ "' where id= '" + id_tache + "'";

            return DataExcute(req);
        }

        public string update_projet2(string intitu, string comm, string net, string avance, string reste, int code)
        {

            function_test();
            string req = "UPDATE projet SET intitu ='" + intitu.Replace("'", "''") + "' ,comm ='" + comm.Replace("'", "''") + "' ,net ='" + net.Replace("'", "''") + "' ,avance ='" + avance.Replace("'", "''") + "' ,reste ='" + reste.Replace("'", "''") + "' where id= '" + code + "'";

            return DataExcute(req);
        }

        public string update_projet3(DateTime date_deb, DateTime date_fin, string equipe_charg , string techno, string etat2, int code)
        {

            function_test();
            string req = "UPDATE projet SET date_deb ='" + date_deb + "' ,date_fin ='" + date_fin + "' ,equipe_charge ='" + equipe_charg.Replace("'", "''") + "' ,techno ='" + techno.Replace("'", "''") + "' ,etat2 ='" + etat2.Replace("'", "''") + "' where id= '"+code+"'";

            return DataExcute(req);
        }
        public string update_projet4(string rec, int code)
        {

            function_test();
            string req = "UPDATE projet SET rec ='" + rec.Replace("'", "''") + "' where id= '" + code + "'";

            return DataExcute(req);
        }

        public string update_projet5(string disc, int code)
        {

            function_test();
            string req = "UPDATE projet SET discuss ='" + disc.Replace("'", "''") + "' where id= '" + code + "'";

            return DataExcute(req);
        }
      
        //modifier utilisateur de type gestion de stock
        public string update_user_gestion_stock(int id, string x1, string x2, string x3, string x4, string x5, string x6, string x7, string x8, string x9, string x10, string x11, string x12, string x13, string x14, string x15, string x16, string x17, string x18, string x19, string x20, string x21, string x22, string x23, string x24, string x25, string x26, string x27, string x28, string x29, string x30, string x31, string x32, string x33, string x34, string x35, string x36, string x37, string x38, string x39, string x40, string x41, string x42)
       {
            function_test();
            string req = "UPDATE droit SET nom ='" + x1 + "', prenom ='" + x2 + "', fonction ='" + x3 + "', depart ='" + x4 + "', gsm ='" + x5 + "', email ='" + x6 + "', login ='" + x7 + "', passwd ='" + x8 + "', visualiser_stock ='" + x9 + "', ajouter_stock ='" + x10 + "', modifier_stock ='" + x11 + "', supprimer_stock ='" + x12 + "', ges_uni ='" + x13 + "', ges_mag ='" + x14 + "', doc_stock ='" + x15 + "', passer_cde ='" + x16 + "', aliment ='" + x17 + "', sortie_prod ='" + x18 + "', alim ='" + x19 + "', sortie_sto ='" + x20 + "', vis_clt ='" + x21 + "', ajout_clt ='" + x22 + "', mod_clt ='" + x23 + "', supp_clt='" + x24 + "', doc_clt= '" + x25 + "', supp_cde_clt= '" + x26 + "', vali_cde_clt= '" + x27 + "', fact= '" + x28 + "', bon_liv ='" + x29 + "', bon_sortie ='" + x30 + "', vis_feur ='" + x31 + "', aj_feur ='" + x32 + "', mod_feur ='" + x33 + "', supp_feur ='" + x34 + "', doc_feur ='" + x35 + "', supp_cde_feur ='" + x36 + "', vis_dev ='" + x37 + "', aj_devis='" + x38 + "', supp_dev= '" + x39 + "', doc_dev= '" + x40 + "', stat= '" + x41 + "', noti= '" + x42 + "' WHERE id_user ='" + id + "'";
           
            return DataExcute(req);
        }
      
        //modifier utilisateur de type admin
        public string update_user_admin(int id, string x1, string x2, string x3, string x4, string x5, string x6, string x7, string x8)
        {
            function_test();
            string req = "UPDATE droit SET nom ='" + x1 + "', prenom ='" + x2 + "', fonction ='" + x3 + "', depart ='" + x4 + "', gsm ='" + x5 + "', email ='" + x6 + "', login ='" + x7 + "', passwd ='" + x8 + "' WHERE id_user ='" + id + "'";
           
            return DataExcute(req);
        }
        public string update_skin(int id, string a)
        {
            function_test();
            if (sql_gmao.conn.State.ToString().Equals("Closed"))
            {
                sql_gmao.conn.Open(); 
            }
            string req = "UPDATE droit SET theme ='" + a + "'WHERE id_user= '" + id + "'";
            return DataExcute(req);
        }
       
        public string update_Administrateur(string nom, string poste, string dep, string gsm, string email, string pwd, string login)
        {
            function_test();
            string req = "UPDATE droit SET n_p ='" + nom + "';fonction ='" + poste + "',depart ='" + dep + "',gsm ='" + gsm + "',email ='" + email + "',passwd ='" + pwd + "' WHERE login='" + login + "' ";
           
            return DataExcute(req);
        }
       
        
        public string update_user(int id, string a, string b, string c)
        {
            function_test();
            string req = "UPDATE droit SET gsm='" + a + "', email='" + b + "', passwd='" + c + "' WHERE id_user='" + id + "'";
          
            return DataExcute(req);
        }
       
        public string delete__pict(int code)
        {
            function_test();
            string req = "DELETE FROM retour WHERE id='" + code + "'";
           
            return DataExcute(req);
        }

        public string delete__projet(int code)
        {
            function_test();
            string req = "DELETE FROM projet WHERE id='" + code + "'";

            return DataExcute(req);
        }

        public string delete__tache(int code)
        {
            function_test();
            string req = "DELETE FROM tache WHERE id='" + code + "'";

            return DataExcute(req);
        }

        public string delete_clt(int code)
        {
            function_test();
            string req = "DELETE FROM client WHERE code_clt='" + code + "'";
            return DataExcute(req);
        }

        public string delete_prospect(int code)
        {
            function_test();
            string req = "DELETE FROM prospection WHERE idprospection='" + code + "'";
            return DataExcute(req);
        }
        public string update_prospect(int code,DateTime dateprosp,string comm,DateTime datrapp)
        {
            function_test();
            string req = "update prospection set dateprospection=@dateprospection, commentaire=@commentaire,daterappel=@daterappel  WHERE idprospection=@idprospection";
            SqlCommand cmd = new SqlCommand(req, sql_gmao.conn);

            cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)dateprosp));
            cmd.Parameters.Add(new SqlParameter("@commentaire", (object)comm));

            cmd.Parameters.Add(new SqlParameter("@daterappel", (object)datrapp));
            cmd.Parameters.Add(new SqlParameter("@idprospection", (object)code));
            

            cmd.ExecuteNonQuery();



            return "true";
           
        }

      
       
        // supprimer user
        public string delete_user(int code)
        {
            function_test();
            string req = "DELETE FROM droit WHERE id_user='" + code + "'";
           
            return DataExcute(req);
        }
       
        public string delete_Admin(int code)
        {
            function_test();
            string req = "DELETE FROM droit WHERE id_user='" + code + "'";
           
            return DataExcute(req);
        }
     
        //*********************************** SLECTION ***********************************

        public string req_select;
     

        public DataTable get_retour1(int a)
        {
            function_test();
            req_select = "SELECT * FROM retour where client='"+a+"'";
            return DataReturn(req_select);
        }
        public DataTable getallprospectbycient(int code)
        {
            function_test();
            req_select = "SELECT * FROM prospection where idclient=@idclient";
            SqlCommand cmd = new SqlCommand(req_select, conn);
            cmd.Parameters.Add(new SqlParameter("@idclient", (object)code));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();
            
         
        }
        public string removeallpr()
        {
            function_test();
            string req = "DELETE FROM prospectionnowaday ";

            return DataExcute(req);


        }
        public string removepr(int idprev)
        {
            function_test();
            string req = "DELETE FROM prospectionnowaday where idprospectprevious='"+idprev+"' ";

            return DataExcute(req);


        }
        public string removeprtomorrow()
        {
            function_test();
            string req = "DELETE FROM prospectiontomorrow  ";

            return DataExcute(req);


        }
        public DataTable getallprospectbydate(DateTime date)
        {
            function_test();
            req_select = "SELECT * FROM prospection where daterappel= @daterappel and etat !=@etat";
            SqlCommand cmd = new SqlCommand(req_select, conn);
            cmd.Parameters.Add(new SqlParameter("@daterappel", (object)date));
            cmd.Parameters.Add(new SqlParameter("@etat", (object)"validé"));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }

        public DataTable getallprospectbydatetomorrow(DateTime date)
        {
            function_test();
            req_select = "SELECT * FROM prospection where daterappel= @daterappel and etat!=@etat ";
            SqlCommand cmd = new SqlCommand(req_select, conn);
            cmd.Parameters.Add(new SqlParameter("@daterappel", (object)date));
            cmd.Parameters.Add(new SqlParameter("@etat", (object)"validé"));
           
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
        public DataTable getallprospectbydatevalide(DateTime date)
        {
            function_test();
            req_select = "SELECT * FROM prospection where dateprospection= @dateprospection and etat =@etat";
            SqlCommand cmd = new SqlCommand(req_select, conn);
            cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)date));
            cmd.Parameters.Add(new SqlParameter("@etat", (object)"non validé"));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
        public DataTable getallprospectbydatenowaday()
        {
            function_test();
            req_select = "SELECT * FROM prospectionnowaday ";
            SqlCommand cmd = new SqlCommand(req_select, conn);
           
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
        public DataTable getallprospect()
        {
            function_test();
            req_select = "SELECT * FROM prospection ";
            SqlCommand cmd = new SqlCommand(req_select, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
        public DataTable getallprospectbymonth(int month)
        {
            function_test();
            req_select = "SELECT * FROM prospection where Month(daterappel)=@month";
            SqlCommand cmd = new SqlCommand(req_select, conn);
            cmd.Parameters.Add(new SqlParameter("@month", (object)month));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
     
        public DataTable getallprospectbydatetomorrow()
        {
            function_test();
            req_select = "SELECT * FROM prospectiontomorrow ";
            SqlCommand cmd = new SqlCommand(req_select, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
        public DataTable getallprospectjournalbydate(DateTime date)
        {
            function_test();
            req_select = "SELECT * FROM prospectionjournalier where dateprospection=@dateprospection ";
            SqlCommand cmd = new SqlCommand(req_select, conn);
            cmd.Parameters.Add(new SqlParameter("@dateprospection", (object)date));
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
            function_test();


        }
        public DataTable get_retour1a(int a, string b)
        {
            function_test();
            req_select = "SELECT * FROM retour where client='" + a + "' and direc!='" + b + "'";
            return DataReturn(req_select);
        }

        public DataTable count_value(string a)
        {
            function_test();
            req_select = "SELECT count(*) FROM client where source='" + a + "'";
            return DataReturn(req_select);
        }

        public DataTable affiche_projet(int a)
        {
            function_test();
            req_select = "SELECT * FROM projet where id='" + a + "'";
            return DataReturn(req_select);
        }

        public DataTable get_projet(int code)
        {
            function_test();
            req_select = "SELECT * FROM projet where id_clt='"+code+"' ";
            return DataReturn(req_select);
        }
        public DataTable get_tache(int code)
        {
            function_test();
            req_select = "SELECT * FROM tache where id_projet='" + code + "' ";
            return DataReturn(req_select);
        }


        public DataTable getmax_id()
        {
            function_test();
            req_select = "SELECT max(UniqueID) FROM Appointments ";
            return DataReturn(req_select);
        }
        public DataTable get_tache2(int code)
        {
            function_test();
            req_select = "SELECT * FROM tache where id='" + code + "' ";
            return DataReturn(req_select);
        }
       

        public DataTable get_clients()
        {
            function_test();
            req_select = "SELECT * FROM client ORDER BY raison_soc ASC";
            return DataReturn(req_select);
        }
       

        public DataTable get_Allclt()
        {
            function_test();
            req_select = "SELECT * FROM client ORDER BY responsbale ASC";
            return DataReturn(req_select);
        }
       



        public DataTable get_cltByCode(int Code)
        {
            function_test();
            req_select = "SELECT * FROM client WHERE code_clt = '" + Code + "'";
            //return DataReturn(req_select);
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(req_select, conn);
            da.Fill(ds, "table");
            DataTable data = new DataTable();
            data = ds.Tables["table"];
            return data;

        }




        //get libellé pieces 
       
        public DataTable combologin()
        {
            function_test();
            req_select = "SELECT * FROM droit";
            return DataReturn(req_select);
        }

        public DataTable log_login(string a, string b)
        {
            function_test();
           
            req_select = "SELECT * FROM droit WHERE login= '" + a + "' AND passwd= '" + b + "' ";
           
            return DataReturn(req_select);
        }
       

        public DataTable affiche_infos_clt(string  clt)
        {
            function_test();
            req_select = "SELECT * FROM client where code_clt='" + clt + "'";
            return DataReturn(req_select);
        }
        // get informations sur la commande fournisseur
       

        //test si utilisateur existe ou pas
        public DataTable test_user(string pseudo)
        {
            function_test();
            req_select = "SELECT * FROM droit WHERE login = '" + pseudo + "'";
            return DataReturn(req_select);
        }
        //afficher liste des utilisateurs dans grid
        public DataTable grid_user()
        {
            function_test();
            req_select = "SELECT * FROM droit";
            return DataReturn(req_select);
        }

       

        public DataTable get_skin(int id)
        {
            function_test();
            req_select = "SELECT skin FROM droit WHERE id_user = '" + id + "' ";
            return DataReturn(req_select);
        }
       
        public DataTable get_AdminById(int idAdm)
        {
            function_test();
            req_select = "SELECT * FROM droit WHERE id_user = '" + idAdm + "'";
            return DataReturn(req_select);
        }
        public DataTable get_AllActions()
        {
            function_test();
            req_select = "SELECT * FROM historique ORDER BY date_hist DESC";
            return DataReturn(req_select);
        }
        public DataTable LoginExist(string login)
        {
            function_test();
            req_select = "SELECT * FROM droit WHERE login = '" + login + "'";
            return DataReturn(req_select);
        }
        
       


      
       
    }
}