using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class Eshopper_afterlogin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            String str1 = "select f_name from Registration where register_id=" + Convert.ToInt32(Session["Userid"]) + ";";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                lbl_fname.Text = dr1[0].ToString();
            }
            dr1.Close();

            ArrayList ar = new ArrayList();

            String str2 = "select product_id from product where buyer_id!=0 and is_sold=0";
            SqlCommand cmd2 = new SqlCommand(str2, con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                ar.Add(dr2[0].ToString());   
            }
            dr2.Close();
            con.Close();

            foreach (String a in ar)
            {
                con.Open();
                String str3 = "select count(*) from product where DATEDIFF(MINUTE,(select end_time from product where product_id=" + Convert.ToInt32(a) + "),SYSDATETIME()) >= 0 and product_id=" + Convert.ToInt32(a) + ";";
                SqlCommand cmd3 = new SqlCommand(str3, con);
                int count = Convert.ToInt32(cmd3.ExecuteScalar());
                con.Close();
                if (count == 1)
                {
                    String str10 = "update product set is_sold=1, update_date='" + System.DateTime.Now + "' where product_id=" + Convert.ToInt32(Request.QueryString["productid"]);
                    con.Open();
                    SqlCommand cmd10 = new SqlCommand(str10, con);
                    cmd10.ExecuteNonQuery();
                }
            }


        }
    }
}
