using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;


public partial class Eshopper_postproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Userid"] == null && Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            showstatus();

            if (Request.QueryString["posted"] == "yes")
            {
                pnl_post.Visible = false;
                pnl_posted.Visible = true;
            }
            else
            {
                pnl_post.Visible = true;
                pnl_posted.Visible = false;
            }
            
        }
    }
    protected void showstatus()
    {
        drp_pcategory.Items.Add("");

        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        String str1 = "select category,category_id from product_category;";
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str1, con);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        while (dr1.Read())
        {
            ListItem item1 = new ListItem(dr1[0].ToString(), dr1[1].ToString());
            drp_pcategory.Items.Add(item1);
        }
        dr1.Close();
        con.Close();
        
    }




    protected void btn_post_Click(object sender, EventArgs e)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["DatabaseServices"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();

        String str1 = "select ISNULL(max(product_id),0) as 'product maximum' from product;";
        SqlCommand cmd1 = new SqlCommand(str1, con);
        int max_product = Convert.ToInt32(cmd1.ExecuteScalar()) + 1;

        string directoryPath = Server.MapPath(string.Format("products/{0}/", max_product.ToString()));
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory in products already exists.');", true);
        }

        string directoryPath1 = Server.MapPath(string.Format("verify/{0}/", max_product.ToString()));
        if (!Directory.Exists(directoryPath1))
        {
            Directory.CreateDirectory(directoryPath1);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Directory in verify already exists.');", true);
        }

        // Image 1

        String ext1 = img1.PostedFile.FileName;

        String[] au1 = ext1.Split('.');

        String a1 = au1[au1.Length - 1];

        String filename1 = "1." + a1;

        img1.SaveAs(Server.MapPath("verify/" + max_product.ToString() + "/" + filename1));

        SharedMethods.ResizeImage(Server.MapPath("verify/" + max_product.ToString() + "/" + filename1), Server.MapPath("products/" + max_product.ToString() + "/" + filename1), 700, 700, ImageFormat.Jpeg);

        FileInfo file1 = new FileInfo(Server.MapPath("verify/" + max_product.ToString() + "/" + filename1));
        file1.Delete();

        // Image 2

        String ext2 = img2.PostedFile.FileName;

        String[] au2 = ext2.Split('.');

        String a2 = au2[au2.Length - 1];

        String filename2 = "2." + a2;

        img2.SaveAs(Server.MapPath("verify/" + max_product.ToString() + "/" + filename2));

        SharedMethods.ResizeImage(Server.MapPath("verify/" + max_product.ToString() + "/" + filename2), Server.MapPath("products/" + max_product.ToString() + "/" + filename2), 700, 700, ImageFormat.Jpeg);

        FileInfo file2 = new FileInfo(Server.MapPath("verify/" + max_product.ToString() + "/" + filename2));
        file2.Delete();

        // Image 3

        String ext3 = img3.PostedFile.FileName;

        String[] au3 = ext3.Split('.');

        String a3 = au3[au3.Length - 1];

        String filename3 = "3." + a3;

        img3.SaveAs(Server.MapPath("verify/" + max_product.ToString() + "/" + filename3));

        SharedMethods.ResizeImage(Server.MapPath("verify/" + max_product.ToString() + "/" + filename3), Server.MapPath("products/" + max_product.ToString() + "/" + filename3), 700, 700, ImageFormat.Jpeg);

        FileInfo file3 = new FileInfo(Server.MapPath("verify/" + max_product.ToString() + "/" + filename3));
        file3.Delete();

        if (Directory.Exists(directoryPath1))
        {
            Directory.Delete(directoryPath1);
        }

        String str = "insert into product values('" + txt_pname.Text + "'," + Convert.ToInt32(drp_pcategory.SelectedValue.ToString()) + ",'" + txt_pdescribe.Text + "','" + filename1 + "','" + filename2 + "','" + filename3 + "'," + Convert.ToInt64(txt_price.Text) + "," + Convert.ToInt32(Session["Userid"].ToString()) + ",0,'" + System.DateTime.Now + "','" + System.DateTime.Now.AddMinutes(2) + "',0,'" + System.DateTime.Now + "')";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
        con.Close();

        Response.Redirect("postproduct.aspx?posted=yes");
    }
}