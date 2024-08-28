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
            String Query = "SELECT * FROM users WHERE username=@user AND password=@pass";
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
                    if (rd != null)
                    {
                        if (rd.HasRows)
                        {
                            Session["username"] = user;
                            Response.Redirect("~/home.html");
                        }
                        else
                        {
                            message.Visible = true;
                            message.Text = "Invalid Username or Password.";
                        }
                    }
                    rd.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                message.Visible = true;
                message.Text = "Some error has occured, please try again.";
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}