using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;

namespace CE34_Project
{
    public partial class BlogDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int blogId = Convert.ToInt32(Request.QueryString["blogId"]);
                LoadBlogDetails(blogId);
                LoadComments(blogId);
            }
        }

        private void LoadBlogDetails(int blogId)
        {
            string query = "SELECT title, body, author FROM blogs WHERE Id = @blogId";
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@blogId", blogId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTitle.Text = reader["title"].ToString();
                    lblBody.Text = reader["body"].ToString();
                    lblAuthor.Text = reader["author"].ToString();
                }
            }
        }

        private void LoadComments(int blogId)
        {
            string query = "SELECT c.comment, u.username, c.timestamp FROM comments c JOIN users u ON c.userId = u.Id WHERE c.blogId = @blogId";
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@blogId", blogId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                CommentsRepeater.DataSource = reader;
                CommentsRepeater.DataBind();
            }
        }

        protected void submitCommentBtn_Click(object sender, EventArgs e)
        {
            int blogId = Convert.ToInt32(Request.QueryString["blogId"]);

            // Check if the user is logged in
            if (Session["userId"] == null)
            {
                message.Text = "You must be logged in to comment.";
                message.Visible = true;
                return; // Prevent further execution
            }

            int userId = Convert.ToInt32(Session["userId"]); // Retrieve the user ID from the session

            string query = "INSERT INTO comments (blogId, userId, comment) VALUES (@blogId, @userId, @comment)";

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@blogId", blogId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@comment", txtComment.Text.Trim());

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); // Execute the command
                if (rowsAffected > 0) // Check if the comment was successfully inserted
                {
                    txtComment.Text = ""; // Clear the comment textbox
                    LoadComments(blogId); // Reload comments to show the new one
                    message.Text = "Comment submitted successfully."; // Set success message
                    message.Visible = true; // Show message
                }
                else
                {
                    message.Text = "Failed to submit the comment. Please try again.";
                    message.Visible = true;
                }
            }
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/homepage.aspx");
        }
    }
}
