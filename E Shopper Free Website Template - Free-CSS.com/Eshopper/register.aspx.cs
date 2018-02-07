using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Eshopper_register : System.Web.UI.Page
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

    protected void btn_register_Click(object sender, EventArgs e)
    {
        String w = null;

        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        con.Open();
        SqlCommand cd = new SqlCommand("select email from Registration where email='" + txt_email.Text + "';", con);
        SqlDataReader rd = cd.ExecuteReader();

        if (rd.Read())
        {
            w = rd[0].ToString();
        }
        rd.Close();
        con.Close();

        if (w != null)
        {
            Response.Redirect("register_success.aspx?already=exists");
        }
        else
        {
            con.Open();
            String str = "";
            if (txt_phone.Text != null && txt_phone.Text != "")
            {
                str = "insert into Registration values('" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_email.Text + "'," + Convert.ToInt64(txt_phone.Text) + ",'" + txt_country.Text + "','" + txt_state.Text + "','" + txt_city.Text + "','" + txt_address.Text + "','" + txt_password.Text + "','" + System.DateTime.Now + "')";
            }
            else
            {
                str = "insert into Registration values('" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_email.Text + "',null,'" + txt_country.Text + "','" + txt_state.Text + "','" + txt_city.Text + "','" + txt_address.Text + "','" + txt_password.Text + "','" + System.DateTime.Now + "')";
            }
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("register_success.aspx?register=success");
        }
    }
}