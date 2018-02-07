using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections;

public partial class Eshopper_dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Userid"] == null && Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            checkmsg();
            getproductdata();

        }
    }

    protected void checkmsg()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();

        ArrayList ai = new ArrayList();

        String str = "select product_id from product where is_sold=0;";
        SqlCommand cmd = new SqlCommand(str, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read())
        {
            ai.Add(dr[0].ToString());
        }
        dr.Close();

        int count1 = 0;

        foreach(string i in ai)
        {
            String str2 = "select count(*) from product where DATEDIFF(MINUTE,(select end_time from product where product_id=" + Convert.ToInt32(i) + "),SYSDATETIME()) >= 0 and product_id=" + Convert.ToInt32(i) + ";";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            int count2 = Convert.ToInt32(cmd2.ExecuteScalar());

            count1 = count1 + count2;

            if (count1 >= 1) break;
        }

        
        if (count1 == 0)
        {
            pnl_noavailable.Visible = true;
            pnl_available.Visible = false;
        }
        else
        {
            pnl_noavailable.Visible = false;
            pnl_available.Visible = true;
        }
        con.Close();
    }

    protected void getproductdata()
    {
        StringBuilder sb = new StringBuilder();
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();


        ArrayList ai = new ArrayList();

        String str = "select product_id from product where is_sold=0;";
        SqlCommand cmd = new SqlCommand(str, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            ai.Add(dr[0].ToString());
        }
        dr.Close();

        foreach (string i in ai)
        {
            String str2 = "select count(*) from product where DATEDIFF(MINUTE,(select end_time from product where product_id=" + Convert.ToInt32(i) + "),SYSDATETIME()) >= 0 and product_id=" + Convert.ToInt32(i) + ";";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            int count2 = Convert.ToInt32(cmd2.ExecuteScalar());

            if (count2 >= 1)
            {
                String str1 = "select product_id,product_name,img1,base_price from product where DATEDIFF(MINUTE,(select end_time from product where product_id=" + Convert.ToInt32(i) + "),SYSDATETIME()) >= 0 and product_id=" + Convert.ToInt32(i) + ";";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    sb.Append("<div class='col-sm-3'>");
                    sb.Append("<div class='product-image-wrapper'>");
                    sb.Append("<div class='single-products'>");
                    sb.Append("<div class='productinfo text-center'>");
                    sb.Append("<img src='products/" + dr1[0].ToString() + "/" + dr1[2].ToString() + "' alt='' />");
                    sb.Append("<h2>$" + dr1[3].ToString() + "</h2>");
                    sb.Append("<p>" + dr1[1].ToString() + "</p>");
                    sb.Append("<a href='productdetails.aspx?productid=" + dr1[0].ToString() + "' class='btn btn-default add-to-cart'>View</a>");
                    sb.Append("</div>");
                    sb.Append("<br />");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                dr1.Close();
            }
        }
        ltr_data.Text = sb.ToString();
        con.Close();
    }

    }