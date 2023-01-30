using System;
using ClassLibrary1;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KnockoutWebformWithController0102
{
    public partial class test : System.Web.UI.Page
    {
        string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            int res = calc(1, 2);
            Message.Text = res.ToString();
        }
        Class1 calculate = new Class1();
        protected void Clickedbutton(object sender, EventArgs e)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insertop";
                using (SqlConnection conn = new SqlConnection(conval))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@name", NameText.Text);
                    cmd.Parameters.AddWithValue("@age", AgeText.Text);
                    cmd.Parameters.AddWithValue("@gender", GenderText.Text);
                    cmd.Parameters.AddWithValue("@address", AddressText.Text);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                response = rdr.GetString(0);
                            }
                        }
                    }

                }
            }

            Message.Text = response;
        }
        protected int calc(int a, int b)
        {
            return calculate.print(a, b);
        }
        protected void deletehere(object sender, GridViewDeleteEventArgs e)
        {
            Message.Text = "";
        }
        protected void RowDeleted(Object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                if (e.AffectedRows == 1)
                {
                    Message.Text = "Record deleted successfully.";
                }
                else
                {
                    Message.Text = "An error occurred during the delete operation.";
                }
            }
            else
            {
                Message.Text = "An error occurred during the delete operation.";
                e.ExceptionHandled = true;
            }

        }
    }
}