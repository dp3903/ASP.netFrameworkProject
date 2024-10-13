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
    public partial class SearchBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                show();
            }
        }

        protected void show()
        {
            string constr = WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString;
            string item = searchInput.Text.Trim();
            string query = "SELECT title,body,author FROM blogs WHERE title LIKE '%" + item + "%'";
            SqlConnection con = new SqlConnection(constr);
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand(query, con);
//                    cmd.Parameters.AddWithValue("@item", item);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        searchResultsRepeater.DataSource = rd;
                        searchResultsRepeater.DataBind();
                    }
                    else
                    {
                        searchResultsRepeater.DataSource = null;
                        searchResultsRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex) 
            {
                Response.Write(ex.ToString());            
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}