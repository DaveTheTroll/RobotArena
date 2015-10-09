using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobotArena;

namespace ArenaWeb
{
    public partial class ArenaListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                UpdateArenas();
        }

        void UpdateArenas()
        {
            BulletedListArena.Items.Clear();
            foreach (Arena arena in Global.Arenas)
            {
                ListItem listItem = new ListItem(arena.ToString(), string.Format("Arena.aspx?arena={0}", arena.Handle));

                BulletedListArena.Items.Add(listItem);
            }
        }

        protected void ButtonAddArena_Click(object sender, EventArgs e)
        {
            Global.Arenas.AddArena(new Arena());
            UpdateArenas();
        }
    }
}