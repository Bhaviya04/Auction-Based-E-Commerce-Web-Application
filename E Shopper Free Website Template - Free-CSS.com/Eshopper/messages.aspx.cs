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

public partial class Eshopper_messages : System.Web.UI.Page
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
            getbuyerdata();

        }
    }

    protected void checkmsg()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "select count(*) from product p join registration r on p.buyer_id=r.register_id where p.buyer_id!=0 and p.seller_id=" + Convert.ToInt32(Session["Userid"]) + ";";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        int count = Convert.ToInt32(cmd1.ExecuteScalar());
        if(count == 0)
        {
            pnl_nomsg.Visible = true;
            pnl_msg.Visible = false;
        }
        else
        {
            pnl_nomsg.Visible = false;
            pnl_msg.Visible = true;
        }
        con.Close();
    }

    protected void getbuyerdata()
    {
        StringBuilder sb1 = new StringBuilder();
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "select p.buyer_id, CONCAT(r.f_name,' ',r.l_name) as 'name', r.email, r.mobile, p.product_name, p.img1, p.product_id from product p join registration r on p.buyer_id=r.register_id where p.buyer_id!=0 and p.seller_id=" + Convert.ToInt32(Session["Userid"]) + ";";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        while (dr1.Read())
        {
            sb1.Append("<tr>");

            sb1.Append("<td class='cart_product'>");
            sb1.Append("<a href='productdetails.aspx?productid=" + dr1[6].ToString() + "'><img src='products/" + dr1[6].ToString() + "/" + dr1[5].ToString() + "' alt='' width='110px' height='110px'></a>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_description'>");
            sb1.Append("<h4><a href='productdetails.aspx?productid=" + dr1[6].ToString() + "'>" + dr1[4].ToString() + "</a></h4>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_price'>");
            sb1.Append("<p>" + dr1[1].ToString() + "</p>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_price'>");
            sb1.Append("<p>" + dr1[2].ToString() + "</p>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_price'>");
            sb1.Append("<p>" + dr1[3].ToString() + "</p>");
            sb1.Append("</td>");

            sb1.Append("</tr>");
        }

        ltr_msg.Text = sb1.ToString();

        dr1.Close();
        con.Close();
    }
}