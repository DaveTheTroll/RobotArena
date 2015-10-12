using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArenaWeb
{
    public partial class WhoAmIPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWho.Text = Context.User.Identity.Name == "" ? "No-one" : Context.User.Identity.Name;
        }
    }
}