using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CE34_Project
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            String user = userName.Text;
            String pass = password.Text;
            String Query = "SELECT Id, username FROM users WHERE username=@user AND password=@pass";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString;
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd != null && rd.HasRows)
                    {
                        rd.Read();
                        Session["userId"] = rd["Id"]; // Store the user ID
                        Session["username"] = user; // Store the username if needed
                        Response.Redirect("~/homepage.aspx"); // Redirect to homepage or keep on the same page
                    }
                    else
                    {
                        message.Visible = true;
                        message.Text = "Invalid Username or Password.";
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                message.Visible = true;
                message.Text = "Some error has occurred, please try again.";
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}