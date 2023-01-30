using Functions.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Garbage_Master_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private BLL _repo;
        protected void Page_Load(object sender, EventArgs e)
        {
            _repo = new BLL();
        }
        [WebMethod]
        public JsonResult QuickMessage(string Name, string Email, string Subject, string Message)
        {

             string abc=_repo.QuickMessage(Name, Email, Subject, Message);  
            return new JsonResult();
        }
    }
}