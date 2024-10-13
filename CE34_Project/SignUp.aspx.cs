using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Configuration;

namespace CE34_Project
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void registerbtn_Click(object sender, EventArgs e)
        {
            message.Visible = true;
            String newuser = userName.Text;
            String pass = password.Text;
            String Query = "INSERT INTO users(username,password) VALUES (@usrnm,@password)";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString;
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Parameters.AddWithValue("@usrnm", newuser);
                    cmd.Parameters.AddWithValue("@password", pass);
                    con.Open();
                    int aff = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                message.Text = "Could not create user. please try again with a different username.";
                return;
            }
            message.Text = "User Created Successfully.";
        }
    }
}