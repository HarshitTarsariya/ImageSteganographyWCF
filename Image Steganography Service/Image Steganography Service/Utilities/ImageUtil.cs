using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography_Service.Utilities
{
    public class ImageUtil
    {
        public CryptoUtil crypto { get; }
        public ImageUtil()
        {
            crypto = new CryptoUtil();
        }


        public byte[] hideMessage(string msg, string mykey, byte[] image, CryptoUtil.Algo algo)
        {
            if (msg == null || msg == "")
                return null;

            byte[] key = null, iv = null, cipher = null;
            (key, iv) = crypto.GetKeyIv(algo, mykey);
            switch (algo)
            {
                case CryptoUtil.Algo.DES:
                    (key, iv, cipher) = crypto.EncryptDES(crypto.Zip(msg), key: key, iv: iv);
                    break;
                default:
                    (key, iv, cipher) = crypto.EncryptAES(crypto.Zip(msg), key: key, iv: iv);
                    break;
            }

            using (var img = new Bitmap(new MemoryStream(image)))
            {
                var maxbytes = (img.Width * img.Height * 3) / 8 - 5;
                if (cipher.Length > maxbytes)
                    return null;
                var binryArr = byteToBits(cipher);
                int k = 0;

                #region hide cipher using LSB
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);
                        byte r = pixel.R, g = pixel.G, b = pixel.B;
                        if (k < binryArr.Length)
                            r = binryArr[k] ? (byte)(r | 1) : (byte)(r & 254);
                        if (k + 1 < binryArr.Length)
                            g = binryArr[k + 1] ? (byte)(g | 1) : (byte)(g & 254);
                        if (k + 2 < binryArr.Length)
                            b = binryArr[k + 2] ? (byte)(b | 1) : (byte)(b & 254);
                        k += 3;
                        img.SetPixel(i, j, Color.FromArgb(r, g, b));
                        if (k >= binryArr.Length)
                            break;
                    }
                    if (k >= binryArr.Length)
                        break;
                }
                #endregion


                #region total number of bytes saved
                img.SetPixel(img.Width - 1, img.Height - 1,
                           Color.FromArgb((byte)(cipher.Length >> 16), (byte)(cipher.Length >> 8),
                           (byte)(cipher.Length)));
                img.SetPixel(img.Width - 1, img.Height - 2,
                    Color.FromArgb(0, 0, (byte)(cipher.Length >> 24)));
                #endregion


                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                byte[] bmpBytes = ms.ToArray();
                return bmpBytes;

                #if DEBUGMODE
                Console.WriteLine("cipher [{1}]: [{0}]", String.Join(",", cipher), cipher.Length);
                printBinArr(binryArr);
                Console.WriteLine(img.GetPixel(img.Width - 1, img.Height - 1));
                Console.WriteLine(img.GetPixel(img.Width - 1, img.Height - 2));
                Console.WriteLine(new String('-', 80));
                #endif
            }

            //return true;
        }

        void printBinArr(bool[] arr)
        {
            int _ = 0;
            foreach (var i in arr)
            {
                Console.Write(i ? 1 : 0);
                if (++_ == 8)
                {
                    Console.Write(" ");
                    _ = 0;
                }
            }
            Console.WriteLine();
        }

        public string extractMessage(byte[] image, string mykey, CryptoUtil.Algo algo)
        {
            string msg = "";
            byte[] key, iv;
            (key, iv) = crypto.GetKeyIv(algo, mykey);
            using (var img = new Bitmap(new MemoryStream(image)))
            {
                Color last1 = img.GetPixel(img.Width - 1, img.Height - 1),
                    last2 = img.GetPixel(img.Width - 1, img.Height - 2);


                int msgSize = BitConverter.ToInt32(
                    new byte[] { last1.B, last1.G, last1.R, last2.B },
                    0);
                var maxbytes = (img.Width * img.Height * 3) / 8 - 5;
                if (msgSize > maxbytes || msgSize <= 0) return "";


                var binryArr = new bool[msgSize * 8];
                int k = 0;


                #region extract cipher using LSB
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        Color pixel = img.GetPixel(i, j);
                        byte r = pixel.R, g = pixel.G, b = pixel.B;
                        if (k < binryArr.Length)
                            binryArr[k] = (r & 1) == 1;
                        if (k + 1 < binryArr.Length)
                            binryArr[k + 1] = (g & 1) == 1;
                        if (k + 2 < binryArr.Length)
                            binryArr[k + 2] = (b & 1) == 1;
                        k += 3;
                        if (k >= binryArr.Length)
                            break;
                    }
                    if (k >= binryArr.Length)
                        break;
                }
                #endregion

                byte[] cipher = bitsToByte(binryArr);
                byte[] decrypted = null;
                switch (algo)
                {
                    case CryptoUtil.Algo.DES:
                        decrypted = crypto.DecryptDES(cipher, key, iv);
                        break;
                    default:
                        decrypted = crypto.DecryptAES(cipher, key, iv);
                        break;
                }
                try
                {
                    msg = crypto.Unzip(decrypted);
                }
                catch (Exception)
                {
                    return "";
                }

                #if DEBUGMODE
                Console.WriteLine(last1);
                Console.WriteLine(last2);
                Console.WriteLine(msgSize);
                printBinArr(binryArr);
                Console.WriteLine("cipher : [{0}]", String.Join(",", cipher));
                #endif

            }

            return msg;
        }

        public bool[] byteToBits(byte[] byts)
        {

            var bits = new bool[byts.Length * 8];


            for (int i = 0; i < byts.Length; i++)
            {
                byte temp = byts[i];
                for (int j = 0; j < 8; j++)
                {
                    bits[i * 8 + j] = temp % 2 == 1;
                    temp /= 2;
                }
            }

            return bits;
        }
        public byte[] bitsToByte(bool[] arr)
        {
            if (arr.Length % 8 != 0)
                throw new ArgumentException("array size must be multiple of 8");
            byte[] ans = new byte[arr.Length / 8];
            for (int i = 0; i < ans.Length; i++)
            {
                byte byt = 0, temp = 1;
                for (int j = 0; j < 8; j++)
                {
                    if (arr[i * 8 + j])
                        byt += temp;
                    temp *= 2;
                }
                ans[i] = byt;
            }
            return ans;
        }
        public string bitsToString(bool[] bits)
        {
            string str = "";
            for (int i = bits.Length - 1; i >= 0; i--)
                str += bits[i] ? "1" : "0";
            return str;
        }
    }
}
