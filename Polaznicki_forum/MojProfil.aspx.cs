using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Polaznicki_forum
    {
    public partial class MojProfil : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {

            if (!(bool)Session["loggedIn"])
                {
                Response.Redirect("~/login.aspx");
                }
            lblKorisnik.Text = (string)Session["userName"];
            lblGrupa.Text = (string)Session["userGroup"];

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["MojaKonekcija"].ConnectionString;

            var cmd = new SqlCommand("SELECT  * FROM korisnici  " +
                " WHERE korisnicko_ime LIKE @userName ", conn);

            cmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = lblKorisnik.Text;

            SqlDataAdapter adptr = new SqlDataAdapter();
            adptr.SelectCommand = cmd;

            SqlCommandBuilder cmdBld = new SqlCommandBuilder(adptr);

            DataTable mojDataTable = new DataTable();
            DataSet mojDataSet = new DataSet();

            adptr.Fill(mojDataSet);
            adptr.Fill(mojDataTable);


            var email = mojDataTable.Rows[0]["email"];
            
            tbxEmail.Text = email.ToString();


            }



        protected void btnPswd_Click(object sender, EventArgs e)
            {

            string userName = lblKorisnik.Text;
            string pass = tbxPwdStari.Text;

            var connStringWbCnfg = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStringWbCnfg);

            connection.Open();

            string mojaKomanda = "SELECT * FROM korisnici WHERE korisnicko_ime LIKE @userName ";


            SqlParameter parameterUserName = new SqlParameter("@userName", userName);
            SqlCommand cmd = new SqlCommand(mojaKomanda, connection);

            cmd.Parameters.Add(parameterUserName);

            var rdr = cmd.ExecuteReader();


                rdr.Read();


                var hash = (string)rdr["hash_zaporke"];

                if (PasswordHash.ValidatePassword(pass, hash))
                    {
                        {

                        var conn2 = new SqlConnection(connStringWbCnfg);
                        var cmd2 = new SqlCommand(mojaKomanda, conn2);

                        cmd2.Parameters.Add("@userName", SqlDbType.NVarChar).Value = lblKorisnik.Text;

                        SqlDataAdapter adptr = new SqlDataAdapter();
                        adptr.SelectCommand = cmd2;

                        SqlCommandBuilder cmdBld = new SqlCommandBuilder(adptr);

                        DataTable korisnik = new DataTable();

                        adptr.Fill(korisnik);

                        var noviHash = PasswordHash.CreateHash(tbxPwdNovi.Text);

                        korisnik.Rows[0]["hash_zaporke"] = noviHash;


                        adptr.Update(korisnik);

                        lblInfo.Text = "paswd promijenjen USPJEŠNO";

                        }
                    }   

                else
                    {
                    lblInfo.Text = (" GREŠKAAAA!!!! korisnik ne postoji u bazi"); 
                    }


                
            connection.Close();
            }


        protected void btnEmail_Click(object sender, EventArgs e)
            {

            }



        }
    }