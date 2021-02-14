using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Image = System.Drawing.Image;
using System.Drawing.Imaging;

namespace Image_Steganography
{
    public partial class _Default : Page
    {
        byte[] saver;
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

            //Encoding Image
            byte[] ret = client.hideMessage(message.Text, "123456789", imgarray, "AES");
            System.Diagnostics.Debug.WriteLine(ret.Length);


            File.WriteAllBytes("f1.txt", ret);
            //Showing Image
            string base64String = Convert.ToBase64String(ret, 0, ret.Length);
            show.ImageUrl = "data:image/png;base64," + base64String;
            
            //Decoding Image
            String ss = client.seekMessage("123456789", ret, "AES");
            System.Diagnostics.Debug.WriteLine(ss+"---");

        }
        protected void decode_Click(object sender, EventArgs e)
        {
            Steganography.HideAndSeekClient client = new Steganography.HideAndSeekClient();
            int imagefilelenth = file.PostedFile.ContentLength;
            byte[] imgarray = new byte[imagefilelenth];
            HttpPostedFile image = file.PostedFile;
            image.InputStream.Read(imgarray, 0, imagefilelenth);
            String ss=client.seekMessage("123456789", imgarray, "AES");
            System.Diagnostics.Debug.WriteLine(ss+"------");
        }
    }
}