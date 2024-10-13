using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CE34_Project
{
    public partial class newBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("~/SignIn.aspx");
                }
                else
                {
                    creator.Text = Session["username"] as string;
                }
            }
        }

        protected void cancelbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/homepage.aspx");
        }

        protected void createbtn_Click(object sender, EventArgs e)
        {
            string blogTitle = title.Text;
            string blogBody = body.Text;
            string publisher = Session["username"] as string;
            string query = "INSERT INTO blogs(title,body,uid,author) VALUES(@blogtitle,@blogbody,(SELECT Id FROM users WHERE username=@publisher),@publisher)";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString;
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@blogtitle", blogTitle);
                    cmd.Parameters.AddWithValue("@blogbody", blogBody);
                    cmd.Parameters.AddWithValue("@publisher", publisher);
                    con.Open();
                    int aff = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                message.Text = "Could not create Blog.";
                return;
            }
            message.Text = "Blog Created Successfully. Go back to home page to see it.";
        }
    }
}