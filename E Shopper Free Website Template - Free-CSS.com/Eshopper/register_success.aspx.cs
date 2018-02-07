using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eshopper_register_success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["register"] == "success")
            {
                pnl_success.Visible = true;
                pnl_exists.Visible = false;
            }
            else if(Request.QueryString["already"] == "exists")
            {
                pnl_exists.Visible = true;
                pnl_success.Visible = false;
            }
        }

    }
}