using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageSteganographyApplication
{
    public partial class DownloadImage : System.Web.UI.Page
    {
        byte[] img;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Image"] == null)
            {
                Response.Redirect("Encode.aspx");
            }
            img = (byte[])Session["Image"];
            Session.Clear();
            String str = Convert.ToBase64String(img);
            preview.Src = "data: image / png; base64," + str;
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