using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CE34_Project
{
	public partial class Profile : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["username"] == null)
            {
                Response.Redirect("~/SignIn.aspx");
            }
            if (!IsPostBack)
			{
				LoadUserBlogs();
			}
		}

		private void LoadUserBlogs()
		{
			string username = Session["username"].ToString();

			UsernameLabel.Text = $"Name: {username}";

			string query = "SELECT * FROM blogs WHERE author = @Author";
			SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString);
			try
			{
				using (con)
				{
					SqlCommand cmd = new SqlCommand(query, con);
					cmd.Parameters.AddWithValue("@Author", username);
					con.Open();
					SqlDataReader reader = cmd.ExecuteReader();

					BlogRepeater.DataSource = reader;
					BlogRepeater.DataBind();

					reader.Close();
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

		protected void DeleteBlog_Click(object sender, EventArgs e)
		{
			Button deleteButton = (Button)sender;
			int blogId = int.Parse(deleteButton.CommandArgument);

			string deleteQuery = "DELETE FROM blogs WHERE Id = @BlogId";
			SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString);

			try
			{
				using (con)
				{
					SqlCommand cmd = new SqlCommand(deleteQuery, con);
					cmd.Parameters.AddWithValue("@BlogId", blogId);
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();

					// Reload the list after deletion
					LoadUserBlogs();
				}
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

		protected void backbtn_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/homepage.aspx");
		}
	}
}
