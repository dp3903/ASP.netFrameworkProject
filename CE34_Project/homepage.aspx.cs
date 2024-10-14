using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace CE34_Project
{
	public partial class homepage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if ( Session["username"] == null)
			{
				Response.Redirect("~/SignIn.aspx");
			}
			if (!IsPostBack)
			{
				LoadBlogs();
			}
			
		}

		private void LoadBlogs()
		{
			string query = "SELECT title, author, body FROM blogs";
			using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString))
			{
				try
				{
					SqlCommand cmd = new SqlCommand(query, con);
					con.Open();
					SqlDataReader rd = cmd.ExecuteReader();

					DataTable dt = new DataTable();
					dt.Load(rd); // Load data into a DataTable

					BlogRepeater.DataSource = dt;
					BlogRepeater.DataBind();

					rd.Close();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		protected void createbtn_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/newBlog.aspx");
		}

		protected void signoutbtn_Click(object sender, EventArgs e)
		{
			Session["username"] = null;
			Response.Redirect("~/SignIn.aspx");
		}

		protected void profilebtn_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Profile.aspx");
		}

        protected void searchbtn_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/SearchBlog.aspx");
        }
    }
}
