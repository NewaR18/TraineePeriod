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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        protected void Submitted(object sender, EventArgs e)
        {
            using(SqlCommand cmd=new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insert1";
                using (SqlConnection conn = new SqlConnection(conval))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@address", address.Text);
                    cmd.ExecuteNonQuery();
                    display1.Text = "Submitted Successfully";
                }
            }
            
        }
        protected void View(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conval))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select* from sudip", conn);
                DataSet d1 = new DataSet("Datas");
                adapter.Fill(d1);
                mygrid.DataSource = d1;
                mygrid.DataBind();
            }
        }
    }
}