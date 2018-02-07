using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Eshopper_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Userid"] == null && Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (Request.QueryString["profileedit"] == "yes")
            {
                pnl_profileedited.Visible = true;
                pnl_profileedit.Visible = false;
            }
            else
            {
                pnl_profileedited.Visible = false;
                pnl_profileedit.Visible = true;
            }

            getprofiledata();
        }
    }

    protected void getprofiledata()
    {
        string f_name="";
        string l_name="";
        string email="";
        string mobile="";
        string country="";
        string state="";
        string city="";
        string address="";

        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        con.Open();
        SqlCommand cd = new SqlCommand("select f_name,l_name,email,mobile,country,state,city,address from Registration where register_id=" + Convert.ToInt32(Session["Userid"]) + ";", con);
        SqlDataReader rd = cd.ExecuteReader();

        if (rd.Read())
        {
            f_name = rd[0].ToString();
            l_name = rd[1].ToString();
            email = rd[2].ToString();
            if(rd[3].ToString() == null || rd[3].ToString() == "")
            {
                mobile = "";
            }
            else
            {
                mobile = rd[3].ToString();
            }
            country = rd[4].ToString();
            state = rd[5].ToString();
            city = rd[6].ToString();
            address = rd[7].ToString();
        }
        rd.Close();
        con.Close();

        txt_fname.Text = f_name;
        txt_lname.Text = l_name;
        txt_email.Text = email;
        txt_phone.Text = mobile;
        txt_country.Text = country;
        txt_state.Text = state;
        txt_city.Text = city;
        txt_address.Text = address;

        txt_email.Enabled = false;

    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        con.Open();
        String str = "";
        if (txt_phone.Text != null && txt_phone.Text != "")
        {
            str = "update Registration set f_name='" + txt_fname.Text + "',l_name='" + txt_lname.Text + "',mobile=" + Convert.ToInt64(txt_phone.Text) + ",country='" +  txt_country.Text + "',state='" + txt_state.Text + "',city='" + txt_city.Text + "',address='" + txt_address.Text + "',password='" + txt_password.Text + "' where register_id=" + Convert.ToInt32(Session["Userid"]);
        }
        else
        {
            str = "update Registration set f_name='" + txt_fname.Text + "',l_name='" + txt_lname.Text + "',mobile=null,country='" + txt_country.Text + "',state='" + txt_state.Text + "',city='" + txt_city.Text + "',address='" + txt_address.Text + "',password='" + txt_password.Text + "' where register_id=" + Convert.ToInt32(Session["Userid"]);
        }
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("profile.aspx?profileedit=yes");
    }
}