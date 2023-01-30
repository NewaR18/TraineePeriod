using masterdetailswithtabs.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace masterdetailswithtabs.Repository
{
    public class CustomerRepo
    {
        
        public void Add()
        {
            string name = "Sudip";
            int age = 15;
            string address = "NetherRealm";
            string phone = "9856984512";
            List<tempclass> tempvalue = new List<tempclass>
            {
                new tempclass { title = "abc",publisher ="def", reference1="ghi" },
                new tempclass { title ="jkl",publisher="mno",reference1="pqr"},
                new tempclass { title="stu",publisher="vwx",reference1="yza"}
            };
            string jsondata = JsonConvert.SerializeObject(tempvalue);
            /*Expected value:
                Customer.Name
                Customer.Age
                Customer.Address
                Customer.PhoneNo
                JSON file containing list of Book.Title,Book.Publisher,Book.Reference*/
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertthis";
                using (SqlConnection conn = new SqlConnection("server=NEWAR-PC; database=MasterDetailWithTabs; Integrated Security=SSPI"))
                {
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 30;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Cname", name);
                    cmd.Parameters.AddWithValue("@cage", age);
                    cmd.Parameters.AddWithValue("@caddress", address);
                    cmd.Parameters.AddWithValue("@cphone", phone);
                    cmd.Parameters.AddWithValue("@json2", jsondata);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
