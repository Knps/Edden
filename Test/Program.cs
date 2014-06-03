using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.core;
using Edden.core.Utils;
using Edden.data.access.layout;
using Edden.data.access.layout.Managers;
using KnpsToolkit.KnpsNetwork;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dao = new DataAccessObject();
            dao.Setup("127.0.0.1", "root", "", "edden");
            try
            {
                dao.InitDb();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
            }
           // Console.ReadLine();

            /*var client = new KnpsClient();
            client.DataReceived += client_DataReceived;
            client.Connect("127.0.0.1", 543);
            client.Send("je suis jonathan", SendDataType.Utf8);*/
        }

        static void client_DataReceived(object sender, byte[] data, int len)
        {
            Console.WriteLine(Encoding.ASCII.GetString(data));
        }
    }
}
