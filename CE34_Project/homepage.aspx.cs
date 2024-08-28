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
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                content.Text = "";
                String query = "SELECT * FROM blogs";
                SqlConnection con = new SqlConnection();
                con.ConnectionString = WebConfigurationManager.ConnectionStrings["BlogCon"].ConnectionString.ToString();
                try
                {
                    using (con)
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        SqlDataReader rd = cmd.ExecuteReader();
                        if (rd != null)
                        {
                            while (rd.Read())
                            {
                                //Response.Write(rd.GetValue(0));
                                //Response.Write(rd.GetValue(1));
                                //Response.Write(rd.GetValue(2));
                                //Response.Write(rd.GetValue(3));
                                content.Text += "<fieldset class=\"blog\">\r\n        <legend class=\"blog-title\">" + rd.GetValue(1) + "</legend>\r\n        <header class=\"blog-author\">" + rd.GetValue(3) + "</header>\r\n        <p class=\"blog-body\">" + rd.GetValue(2) + "</p>\r\n    </fieldset>";
                            }
                        }
                        rd.Close();
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Response.Write(ex.Message);
                }
            }
        }
    }
}