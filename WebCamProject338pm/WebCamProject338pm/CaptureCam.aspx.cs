using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;

namespace MyWebCamImage
{
    public partial class CaptureCam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.InputStream.Length > 0)
                {
                    using (StreamReader myreader = new
                       StreamReader(Request.InputStream))
                    {
                        string myhexString = Server.UrlEncode
                           (myreader.ReadToEnd());
                        string myimageName = DateTime.Now.ToString
                           ("dd-MM-yy hh-mm-ss");
                        string myimagePath = string.Format
                           ("~/Captures/{0}.png", myimageName);
                        File.WriteAllBytes(Server.MapPath(myimagePath),
                           ConvertHexToBytes(myhexString));
                        Session["MyCapturedImage"] =
                           ResolveUrl(myimagePath);
                    }
                }
            }
        }


        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2),
                   16);
            }
            return bytes;
        }


        [WebMethod(EnableSession = true)]
        public static string GetMyCapturedImage()
        {
            string Imageurl = HttpContext.Current.Session
               ["MyCapturedImage"].ToString();
            HttpContext.Current.Session["MyCapturedImage"] = null;
            return Imageurl;
        }
    }
}