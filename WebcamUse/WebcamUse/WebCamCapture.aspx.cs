using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebcamUse
{
    public partial class WebCamCapture : System.Web.UI.Page
    {
        string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(conval);
                // connection of sql   
                // used this StoredProcedure for reteriving image  
                // According to user id i am reteriving image from database  
                SqlCommand cmd = new SqlCommand("insertimages", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userimagename", "");
                cmd.Parameters.AddWithValue("@userimagepath", null);
                cmd.Parameters.AddWithValue("@userid", 0);
                cmd.Parameters.AddWithValue("@queryid", 2);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    img.ImageUrl = ds.Tables[0].Rows[0]["UserImagePath"].ToString();
                    // Assiging image to Image Control  
                }
            }
        }
        protected void Linkbutton1_Click(object sender, EventArgs e)
        {
            // to how Pop and calling another Page in Popup.  
            string url = "/WebCam/Captureimage.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=900,height=460,left=100,top=100,resizable=no');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}