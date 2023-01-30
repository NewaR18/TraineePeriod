using ASPNETCOREAJAX.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ASPNETCOREAJAX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public JsonResult GetNames()
        {
            var datas = new List<Books>();
            using(SqlCommand cmd=new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from InfoTable";
                using (SqlConnection conn1 = new SqlConnection("server=NEWAR-PC; database=InfoAPI; Integrated Security=SSPI;"))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                Books s1 = new Books();
                                s1.Id=rd.GetInt32(0);
                                s1.Name=rd.GetString(1);
                                s1.Publisher = rd.GetString(2);
                                s1.Price = rd.GetInt32(3);
                                datas.Add(s1);
                            }
                        }
                    }
                }
            }
            return new JsonResult(Ok(datas));
        }
        [HttpPost]
        public JsonResult PostName(int id, string name, string production, int price)
        {
            int n = 0;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into InfoTable values ({id},'{name}','{production}',{price})";
                using (SqlConnection conn1 = new SqlConnection("server=NEWAR-PC; database=InfoAPI; Integrated Security=SSPI;"))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    n = cmd.ExecuteNonQuery();
                }
            }
            return new JsonResult(n);
        }
    }
}