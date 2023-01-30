using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable d1 = new DataTable();
            using (SqlConnection conn = new SqlConnection(conval))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select* from sudip ", conn);
                
                adapter.Fill(d1);
                gridview1.DataSource = d1;
                gridview1.DataBind();
            }
        }
        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(gridview1.DataKeys[e.RowIndex].Values["id"].ToString());
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "delete1";
                using (SqlConnection conn = new SqlConnection(conval))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}