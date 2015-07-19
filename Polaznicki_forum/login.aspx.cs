using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Polaznicki_forum
    {
    public partial class WebForm11 : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {


            }

        protected void Button1_Click(object sender, EventArgs e)
            {
            string userName = this.tbxlogin.Text;
            string pass = this.tbxpass.Text;

            var connStringWbCnfg = ConfigurationManager.ConnectionStrings["mojaKonekcija"].ConnectionString;
            SqlConnection connection = new SqlConnection(connStringWbCnfg);

            connection.Open();

            string mojaKomanda = "SELECT TOP 1 * FROM korisnici  k inner join " +
                "grupe_korisnika g on g.id_grupa = k.grupa_id WHERE korisnicko_ime LIKE @userName ";


            SqlParameter parameterUserName = new SqlParameter("@userName", userName);

            //parameterUserName.DbType = System.Data.DbType.String;
            //parameterUserName.Direction = System.Data.ParameterDirection.Output;
            //parameterUserName.ParameterName = "@userName";
            //parameterUserName.Value = userName;



            SqlCommand cmd = new SqlCommand(mojaKomanda, connection);

            cmd.Parameters.Add(parameterUserName);
            //cmd.Parameters.Add(parameterPass);



            var rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
                {
                rdr.Read();


                var hash = (string)rdr["hash_zaporke"];

                if (PasswordHash.ValidatePassword(pass, hash))
                    {
                        {
                        Session["loggedIn"] = true;
                        Session["userName"] = userName;
                        Session["userGroup"] = (string)rdr["naziv_grupe"];
                        Response.Write("korisnik je dodan, uspjesan login");

                        Response.Redirect("~/Home.aspx");
                        }
                    }

                else
                    {
                    Response.Write(" GREŠKAAAA!!!! korisnik ne postoji u bazi");
                    }


                }
            connection.Close();
            }


            }
        }
    