using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Polaznicki_forum
    {
    public partial class HomePage : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {


            if ((bool)Session["loggedIn"] == false)
                {
                Response.Redirect("~/login.aspx");
                }  
            }
        }
    }