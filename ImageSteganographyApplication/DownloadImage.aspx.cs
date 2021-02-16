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
        string str;
        public string Str { get { return str; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Image"] == null)
            {
                //Response.Redirect("DownloadImage.aspx");
                Response.Redirect("Encode.aspx");
            }
            img = (byte[]) Session["Image"];
            Session.Clear();
            str = Convert.ToBase64String(img);
            preview.Src = "data:image/png;base64," + str;
        }

        protected void BackToEncodePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Encode.aspx");
        }

        protected void DownloadEncodedImage_Click(object sender, EventArgs e)
        {
            //string downloadFile = preview.Src;
            //string fileName = "decode";
            //Response.Clear();
            //Response.ContentType = "image/png; base64";
            //Response.AppendHeader("Content-Disposition","attachment;filename=" + fileName + ";");
            //Response.TransmitFile(Server.MapPath(downloadFile));
            //Response.End(); 
            Response.Redirect("DownloadImage.aspx");
        }
    }
}