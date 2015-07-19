using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Polaznicki_forum
    {
    public partial class Main : System.Web.UI.MasterPage
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if ((bool)Session["loggedIn"])
                {
                this.div_korisnik.InnerHtml = string.Format("Zdravo {0} <a href=\"loggedOut.aspx\"> odjava </a> | <a href=\"MojProfil.aspx\"> MOJ PROFIL </a>",Session["userName"]);
                }
            else
                {
                this.div_korisnik.InnerHtml = "<a href=\"login.aspx\"> prijava </a> | <a href=\"register.aspx\"> registracija </a> | <a href=\"MojProfil.aspx\"> MOJ PROFIL </a>";
                }
            }
        }
    }