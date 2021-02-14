using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost host=new ServiceHost(typeof(Image_Steganography_Service.HideAndSeek)))
            {
                host.Open();
                Console.WriteLine("Service is Hosted and is Running !");
                Console.ReadLine();
            }
        }
    }
}
