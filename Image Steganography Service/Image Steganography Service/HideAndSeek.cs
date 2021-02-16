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
        public byte[] hideMessage(string msg, string key, byte[] cover, string encryptType)
        {
            Console.WriteLine("Image reached when encoding size in bytes:"+cover.Length.ToString());
            return util.hideMessage(msg, key, cover, (encryptType.Equals("DES"))? CryptoUtil.Algo.DES:CryptoUtil.Algo.AES );
            
        }

        public string seekMessage(string key, byte[] coverWithData, string encryptType)
        {
            Console.WriteLine("Image reached when decoding size in bytes:" + coverWithData.Length.ToString());
            return util.extractMessage(coverWithData, key, (encryptType.Equals("DES")) ? CryptoUtil.Algo.DES : CryptoUtil.Algo.AES);
            
        }
    }
}
