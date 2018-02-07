using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Eshopper_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Userid"] != null && Session["Email"] != null)
            {
                Response.Redirect("dashboard.aspx");
            }
        }
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        String str = "";
        str = "select count(*) from Registration where email='" + txt_email.Text + "' and password='" + txt_password.Text + "';";
        SqlCommand cmd = new SqlCommand(str, con);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        con.Close();
        if (count == 1)
        {
            lbl_nomatch.Visible = false;
            String str1 = "select register_id,email from Registration where email='" + txt_email.Text + "' and password='" + txt_password.Text + "';";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while(dr1.Read())
            {
                Session["Userid"] = dr1[0].ToString();
                Session["Email"] = dr1[1].ToString();
            }
            dr1.Close();
            con.Close();
            Response.Redirect("dashboard.aspx");
        }
        else if(count == 0)
        {
            lbl_nomatch.Visible = true;
        }
    }
}