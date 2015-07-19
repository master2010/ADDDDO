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
    public partial class Registracija : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            var username = this.tbxUserName.Text;
            if (!(this.tbxPw1.Text==this.tbxPw2.Text))
                {
                this.par_obj.InnerText = "passwordi se ne poklapaju";
                return;
                }
            var password = this.tbxPw1.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
                ConfigurationManager.ConnectionStrings["MojaKonekcija"].ConnectionString;
            var mojKomanda = "SELECT TOP 1 * FROM korisnici  " +
                " WHERE korisnicko_ime LIKE @userName ";
            var komanda = new SqlCommand(mojKomanda, conn);


            komanda.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = username;


            try
                {
                conn.Open();

                SqlDataReader rdr = komanda.ExecuteReader();

                if (rdr.HasRows)
                    {

                    this.par_obj.InnerHtml = "KORISNIK S TIM imenom VEC POSTOJI";
                    return;

                    }

                rdr.Close();

                var hash = PasswordHash.CreateHash(password);

                mojKomanda = "insert into korisnici(korisnicko_ime,hash_zaporke,grupa_id) values (@username,@hash,2)";

                komanda = new SqlCommand(mojKomanda, conn);

                komanda.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = username;
                komanda.Parameters.Add("@hash", System.Data.SqlDbType.NVarChar).Value = hash;

                var brojPromjena = komanda.ExecuteNonQuery();

                if (brojPromjena==1)
                    {
                    this.par_obj.InnerHtml = "KORISNIK USPJEŠNO KREIRAN!!!!!!!!!!";
                    }

                }
            catch (Exception)
                {

                }
            finally
                {
                conn.Close();
                }
            






            

            }
        }
    }