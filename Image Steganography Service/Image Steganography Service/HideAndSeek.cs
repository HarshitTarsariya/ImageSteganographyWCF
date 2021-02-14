using Image_Steganography_Service.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Image_Steganography_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HideAndSeek" in both code and config file together.
    public class HideAndSeek : IHideAndSeek
    {
        ImageUtil util;
        public HideAndSeek()
        {
            util = new ImageUtil();
        }
        public String hideMessage(string msg, string key, String cover, string encryptType)
        {
            var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(cover)));
            return util.hideMessage(msg, key, img, (encryptType == "DES") ? CryptoUtil.Algo.DES : CryptoUtil.Algo.AES);
        }

        public string seekMessage(string key, String coverWithData, string encryptType)
        {
            var img = Image.FromStream(new MemoryStream(Convert.FromBase64String(coverWithData)));
            return util.extractMessage(img, key, (encryptType == "DES") ? CryptoUtil.Algo.DES : CryptoUtil.Algo.AES);
            
        }
    }
}
