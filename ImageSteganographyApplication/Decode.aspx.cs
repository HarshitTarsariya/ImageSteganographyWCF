using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImageSteganographyApplication
{
    public partial class Decode : System.Web.UI.Page
    {
        Steganography.HideAndSeekClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Steganography.HideAndSeekClient();
            error.Visible = false;
            finalmessage.InnerText = "";
        }
        protected void DecodeSubmitButton_Click(object sender, EventArgs e)
        {
            int imagefilelenth = image_upload.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = image_upload.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);

            //Decoding Message
            String msg;
            msg= client.seekMessage(key.Text, imgarray, encrypt.Text);
            if (msg.Equals(""))
            {
                error.Visible = true;
            }
            else
            {
                finalmessage.InnerText = msg;
            }
        }
    }
}