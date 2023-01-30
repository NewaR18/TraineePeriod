using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Functions.Business_Logic_Layer;
namespace Garbage_Master_Web
{
    public class MainController
    {
        private readonly BLL _repo;
        public MainController()
        {
            _repo = new BLL();
        }
        [HttpPost]
        [WebMethod]
        public JsonResult PostName(string Name, string Email, string Subject, string Message)
        {
            _repo.QuickMessage(Name,Email,Subject,Message);
            return new JsonResult();
        }
    }
}