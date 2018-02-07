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
using System.Globalization;

public partial class Eshopper_productpurchased : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Userid"] == null && Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            checkpurchased();
            getpurchaseddata();

        }
    }

    protected void checkpurchased()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "select count(*) from product where buyer_id=" + Convert.ToInt32(Session["Userid"]) + " and is_sold=1;";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        int count = Convert.ToInt32(cmd1.ExecuteScalar());
        if (count == 0)
        {
            pnl_nopurchased.Visible = true;
            pnl_purchased.Visible = false;
        }
        else
        {
            pnl_nopurchased.Visible = false;
            pnl_purchased.Visible = true;
        }
        con.Close();
    }

    protected void getpurchaseddata()
    {
        StringBuilder sb1 = new StringBuilder();
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "select p.product_id,p.img1,p.product_name,p.base_price,p.update_date,c.category from product p join product_category c on p.category_id=c.category_id where p.buyer_id=" + Convert.ToInt32(Session["Userid"]) + " and p.is_sold=1;";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        while (dr1.Read())
        {
            sb1.Append("<tr>");

            sb1.Append("<td class='cart_product'>");
            sb1.Append("<a href='productdetails.aspx?productid=" + dr1[0].ToString() + "'><img src='products/" + dr1[0].ToString() + "/" + dr1[1].ToString() + "' alt='' width='110px' height='110px'></a>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_description'>");
            sb1.Append("<h4><a href='productdetails.aspx?productid=" + dr1[0].ToString() + "'>" + dr1[2].ToString() + "</a></h4>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_price'>");
            sb1.Append("<p>$" + dr1[3].ToString() + "</p>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_price'>");
            sb1.Append("<p>" + dr1[5].ToString() + "</p>");
            sb1.Append("</td>");

            sb1.Append("<td class='cart_price'>");
            //  sb1.Append("<p>" + Convert.ToDateTime(dr1[4].ToString()) + "</p>");
            sb1.Append("<p>" + DateTime.Parse(dr1[4].ToString()).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) + "</p>");
            sb1.Append("</td>");

            sb1.Append("</tr>");
        }

        ltr_purchased.Text = sb1.ToString();

        dr1.Close();
        con.Close();
    }

}