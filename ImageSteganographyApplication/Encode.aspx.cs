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
        Steganography.HideAndSeekClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Steganography.HideAndSeekClient();
            error.Visible = false;
        }

        protected void EncodeSubmitButton_Click(object sender, EventArgs e)
        {
            int imagefilelenth = image_upload.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = image_upload.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);


            //Encoding Image
            byte[] ret = client.hideMessage(message.Text, key.Text, imgarray, encrypt.Text);
            if (ret == null)
            {
                error.Visible = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(ret.Length);

                Session.Add("Image", ret);
                Response.Redirect("DownloadImage.aspx");
            }
        }
    }
}