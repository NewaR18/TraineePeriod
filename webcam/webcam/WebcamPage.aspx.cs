using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AForge.Video;
using AForge.Video.DirectShow;

namespace webcam
{
    public partial class WebcamPage : System.Web.UI.Page
    {
        private Webcam webcam;

        protected void Page_Load(object sender, EventArgs e)
        {
            webcam = new Webcam();
            webcam.NewFrame += new NewFrameEventHandler(webcam_NewFrame);
            webcam.Start();
        }

        void webcam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            webcamImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String((byte[])eventArgs.Frame.Clone());
        }
    }
}