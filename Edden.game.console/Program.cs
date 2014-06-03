using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Edden.game.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "";
            var core = new GameCore();
            core.Log.NewMessage += Log_NewMessage;
            core.Log.NewException += Log_NewException;
            core.Run();
            Console.ReadLine();
        }

        static void Log_NewException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        static void Log_NewMessage(core.Models.MessageLogModel message)
        {
            Console.WriteLine(message.Message);
        }
    }
}
