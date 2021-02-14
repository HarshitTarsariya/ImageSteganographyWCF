using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Image = System.Drawing.Image;

namespace Image_Steganography
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Steganography.HideAndSeekClient client = new Steganography.HideAndSeekClient();
            int imagefilelenth = file.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = file.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);
            String str=Convert.ToBase64String(imgarray);
            String ret=client.hideMessage(message.Text,"123456789",str,"DES");
            //ret.Save("received.png");

        }
    }
}