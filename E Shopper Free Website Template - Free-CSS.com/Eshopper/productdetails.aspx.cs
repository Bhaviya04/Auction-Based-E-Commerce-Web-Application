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

public partial class Eshopper_productdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Userid"] == null && Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (Request.QueryString["buy"] == "yes")
            {
                pnl_beforebuy.Visible = false;
                pnl_afterbuy.Visible = true;
            }
            else
            {
                pnl_beforebuy.Visible = true;
                pnl_afterbuy.Visible = false;
            }

            getproductdata();
            checksold();
            checkauction();

        }
    }

    protected void getproductdata()
    {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();
        StringBuilder sb4 = new StringBuilder();
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "select p.product_id,p.product_name,c.category,p.product_describe,p.img1,p.img2,p.img3,p.base_price,p.seller_id from product p join product_category c on p.category_id=c.category_id where p.product_id=" + Convert.ToInt32(Request.QueryString["productid"]) + ";";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        while (dr1.Read())
        {
            sb1.Append("<div class='col-sm-5'>");
            sb1.Append("<div class='view-product'>");
            sb2.Append("</div>");
            sb2.Append("<div id='similar-product' data-ride='carousel'>");
            sb2.Append("<div class='carousel-inner'>");
            sb2.Append("<div class='item active'>");
            sb3.Append("</div>");
            sb3.Append("</div>");
            sb3.Append("</div>" );
            sb3.Append("</div>");
            sb3.Append("<div class='col-sm-7'>");
            sb3.Append("<div class='product - information'>");
            sb3.Append("<h2>" + dr1[1].ToString() + "</h2>");
            lbl_baseprice.Text = dr1[7].ToString();
            sb4.Append("<p><b>Category:</b> " + dr1[2].ToString() + "</p>");
            sb4.Append("<p align='justify'><b>Description:</b> " + dr1[3].ToString() + "</p>");
            sb4.Append("<p align='justify'><font color='red'><b>Note:</b> If you buy this product, then your details will be shared to the seller who posted this product.</font color></p>");
            if (Request.QueryString["auction"] == "yes")
            {
                sb4.Append("<p align='justify'><font color='red'><b>Note:</b> Bid this product only when you are thinking of buying it.Bid price should always be more than the base price.</font color></p>");
            }
            sb4.Append("</div>");
            sb4.Append("</div>");

            img_main.ImageUrl = "products/" + dr1[0].ToString() + "/" + dr1[4].ToString();
            img1.ImageUrl = "products/" + dr1[0].ToString() + "/" + dr1[4].ToString();
            img2.ImageUrl = "products/" + dr1[0].ToString() + "/" + dr1[5].ToString();
            img3.ImageUrl = "products/" + dr1[0].ToString() + "/" + dr1[6].ToString();

            if(Convert.ToInt32(dr1[8].ToString()) == Convert.ToInt32(Session["Userid"].ToString()))
            {
                btn_buy.Enabled = false;
            }
            else
            {
                btn_buy.Enabled = true;
            }

        }
        ltr_data1.Text = sb1.ToString();
        ltr_data2.Text = sb2.ToString();
        ltr_data3.Text = sb3.ToString();
        ltr_data4.Text = sb4.ToString();
        dr1.Close();
        con.Close();
    }

    protected void checksold()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        String str1 = "select is_sold from product where product_id=" + Convert.ToInt32(Request.QueryString["productid"]);
        SqlCommand cmd = new SqlCommand(str1,con);
        int is_sold = Convert.ToInt32(cmd.ExecuteScalar());
        if(is_sold==0)
        {
            btn_buy.Visible = true;
        }
        else
        {
            btn_buy.Visible = false;
        }
        con.Close();
    }

    protected void checkauction()
    {
        if (Request.QueryString["auction"] == "yes")
        {
            long auction_bid = 0;

            pnl_beforebuy.Visible = true;
            pnl_auction.Visible = true;
            btn_buy.Visible = false;
            pnl_afterbuy.Visible = false;

            string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            String str1 = "select base_price,seller_id,buyer_id from product where product_id=" + Convert.ToInt32(Request.QueryString["productid"]) + ";";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                auction_bid = Convert.ToInt64(dr1[0].ToString()) + 1;

                if (Convert.ToInt32(dr1[1].ToString()) == Convert.ToInt32(Session["Userid"].ToString()))
                {
                    btn_bid.Enabled = false;
                }
                else
                {
                    btn_bid.Enabled = true;
                }

                if(Convert.ToInt32(Session["Userid"]) == Convert.ToInt32(dr1[2].ToString()))
                {
                    lbl_highestbidder.Visible = true;
                }

            }
            dr1.Close();
            con.Close();

            rng_bid.MinimumValue = auction_bid.ToString();

        }
    }


    protected void img1_Click(object sender, ImageClickEventArgs e)
    {
        img_main.ImageUrl = img1.ImageUrl;
    }
    protected void img2_Click(object sender, ImageClickEventArgs e)
    {
        img_main.ImageUrl = img2.ImageUrl;
    }
    protected void img3_Click(object sender, ImageClickEventArgs e)
    {
        img_main.ImageUrl = img3.ImageUrl;
    }

    protected void btn_buy_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "update product set buyer_id=" + Convert.ToInt32(Session["Userid"].ToString()) + ",is_sold=1, update_date='" + System.DateTime.Now + "' where product_id=" + Convert.ToInt32(Request.QueryString["productid"]);
        con.Open();
        SqlCommand cmd = new SqlCommand(str1,con);
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("productdetails.aspx?buy=yes");
    }

    protected void btn_bid_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "update product set base_price=" + Convert.ToInt64(txt_bid.Text) + ",buyer_id=" + Convert.ToInt32(Session["Userid"].ToString()) + ",update_date='" + System.DateTime.Now + "' where product_id=" + Convert.ToInt32(Request.QueryString["productid"]);
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        cmd1.ExecuteNonQuery();
        con.Close();

        getproductdata();

        long minimum_value = Convert.ToInt64(txt_bid.Text) + 1;

        rng_bid.MinimumValue = minimum_value.ToString();

        lbl_highestbidder.Visible = true;

        txt_bid.Text = "";

    }

    protected void GetTime(object sender, EventArgs e)
    {

        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();

        DateTime dt = Convert.ToDateTime("00:00:00");

        String str2 = "select end_time from product where product_id=" + Convert.ToInt32(Request.QueryString["productid"]) + ";";
        SqlCommand cmd2 = new SqlCommand(str2, con);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        while(dr2.Read())
        {
            dt = Convert.ToDateTime(dr2[0].ToString());
        }
        dr2.Close();

        con.Close();

        TimeSpan date_diff = dt - System.DateTime.Now;

        lblTime.Text = string.Format("{0}:{1}:{2}", date_diff.Hours, date_diff.Minutes, date_diff.Seconds);

        String str1 = "select base_price,buyer_id from product where product_id=" + Convert.ToInt32(Request.QueryString["productid"]) + ";";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        while (dr1.Read())
        {
            lbl_baseprice.Text = dr1[0].ToString();

            if (Convert.ToInt32(Session["Userid"]) == Convert.ToInt32(dr1[1].ToString()))
            {
                lbl_highestbidder.Visible = true;
            }
            else
            {
                lbl_highestbidder.Visible = false;
            }

        }
        dr1.Close();
        con.Close();

        if(date_diff.Hours == 0 && date_diff.Minutes == 0 && date_diff.Seconds == 0)
        {
            String str = "select buyer_id from product where product_id=" + Convert.ToInt32(Request.QueryString["productid"]) + ";";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            int buyer = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if(buyer == 0)
            {
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                String str10 = "update product set is_sold=1, update_date='" + System.DateTime.Now + "' where product_id=" + Convert.ToInt32(Request.QueryString["productid"]);
                con.Open();
                SqlCommand cmd10 = new SqlCommand(str10, con);
                cmd10.ExecuteNonQuery();
                con.Close();

                if (buyer == Convert.ToInt32(Session["Userid"]))
                {
                    Response.Redirect("productdetails.aspx?buy=yes");
                }
                else
                {
                    Response.Redirect("dashboard.aspx");
                }
            }
        }

    }

}