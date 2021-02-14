using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageSteganographyApplication
{
    public partial class DownloadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BackToEncodePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Encode.aspx");
        }

        protected void DownloadEncodedImage_Click(object sender, EventArgs e)
        {
            Response.Redirect("DownloadImage.aspx");
        }
    }
}