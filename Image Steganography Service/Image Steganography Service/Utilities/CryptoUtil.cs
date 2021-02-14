using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography_Service.Utilities
{
    public class CryptoUtil
    {
        #region Properties
        public enum Algo { AES, DES }
        public byte[] AES_KEY { get => new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; }
        public byte[] AES_IV { get => new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; }
        public byte[] DES_KEY { get => new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff }; }
        public byte[] DES_IV { get => new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; }

        #endregion


        public void hello()
        {
            string original = "It fills my heart with joy unspeakable to rise in response to the warm and cordial welcome" +
                " which you have given us. I thank you in the name of the most ancient order of monks in the world;" +
                " I thank you in the name of the mother of religions;" +
                " and I thank you in the name of millions and millions of Hindu people of all classes and sects.";

            var aeskey = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            var aesiv = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            var deskey = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff };
            var desiv = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };


            var compressed = Zip(original);
            var (key, iv, cipher) = EncryptDES(compressed);
            var decrypted = DecryptDES(cipher, key, iv);
            var decompressed = Unzip(decrypted);

            Console.WriteLine("[{0}] ==> [{1}]", original.Length, original);
            Console.WriteLine("[{0}] ==> [{1}]", compressed.Length, String.Join(",", compressed));
            Console.WriteLine("[{0}] ==> [{1}]", cipher.Length, String.Join(",", cipher));
            Console.WriteLine("[{0}] ==> [{1}]", decrypted.Length, String.Join(",", decrypted));
            Console.WriteLine("[{0}] ==> [{1}]", decompressed.Length, decompressed);

        }

        public (byte[], byte[]) GetKeyIv(Algo algo, string _key)
        {
            var key = Encoding.UTF8.GetBytes(_key);
            if (algo == Algo.AES)
            {
                byte[] key1 = AES_KEY, iv1 = AES_IV;
                for (int i = 0; i < Math.Min(key.Length, 16); i++)
                {
                    key1[i] ^= key[i];
                    iv1[i] ^= key[i];
                }
                return (key1, iv1);
            }
            else
            {
                byte[] key1 = DES_KEY, iv1 = DES_IV;
                for (int i = 0; i < Math.Min(key.Length, 8); i++)
                {
                    key1[i] ^= key[i];
                    iv1[i] ^= key[i];
                }
                return (key1, iv1);
            }
        }

        /// <summary>
        /// returns (key,iv,cipher)
        /// </summary>
        public (byte[], byte[], byte[]) EncryptAES(byte[] plaintxt, byte[] key = null, byte[] iv = null)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;

                if (key != null)
                    aes.Key = key;
                if (iv != null)
                    aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    return (aes.Key, aes.IV, PerformCryptography(plaintxt, encryptor));
                }
            }
        }

        public byte[] DecryptAES(byte[] ciphertxt, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = 128;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;

                aes.Key = key;
                aes.IV = iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(ciphertxt, decryptor);
                }
            }
        }
        /// <summary>
        /// returns (key,iv,cipher)
        /// </summary>
        public (byte[], byte[], byte[]) EncryptDES(byte[] plaintxt, byte[] key = null, byte[] iv = null)
        {
            using (var des = DES.Create())
            {
                des.KeySize = 64;
                des.BlockSize = 64;
                des.Padding = PaddingMode.Zeros;

                if (key != null)
                    des.Key = key;

                if (iv != null)
                    des.IV = iv;

                using (var encryptor = des.CreateEncryptor(des.Key, des.IV))
                {
                    return (des.Key, des.IV, PerformCryptography(plaintxt, encryptor));
                }
            }
        }
        public byte[] DecryptDES(byte[] ciphertxt, byte[] key, byte[] iv)
        {
            using (var des = DES.Create())
            {
                des.BlockSize = 64;
                des.KeySize = 64;
                des.Padding = PaddingMode.Zeros;

                des.Key = key;
                des.IV = iv;

                using (var decryptor = des.CreateDecryptor(des.Key, des.IV))
                {
                    return PerformCryptography(ciphertxt, decryptor);
                }
            }
        }

        byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();

                return ms.ToArray();
            }
        }
        public byte[] Zip(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }
                return mso.ToArray();
            }
        }

        public string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
    }
}
