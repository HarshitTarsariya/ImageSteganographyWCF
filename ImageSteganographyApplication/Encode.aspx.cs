using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageSteganographyApplication
{
    public partial class Encode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EncodeSubmitButton_Click(object sender, EventArgs e)
        {
            Steganography.HideAndSeekClient client = new Steganography.HideAndSeekClient();

            int imagefilelenth = file.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = file.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);

            //Encoding Image
            byte[] ret = client.hideMessage(message.Text,key.Text, imgarray, "AES");
            System.Diagnostics.Debug.WriteLine(ret.Length);
            //Response.Redirect("DownloadImage.aspx");
        }
    }
}