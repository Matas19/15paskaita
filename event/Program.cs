using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @event
{
    class Program
    {
        //public event EventHandler ManoEvent;

        static void Main(string[] args)
        {
            string logPath = "../../Bank_logs.txt";
            TikrintiLoga(logPath);      //istrina log.txt faila pries pradedant darba

            //sukuriame banko sanskaitos objekta
            Bankas manoBankas = new Bankas("Swed", 5268.62);


            //sukuriame isvedimui skirtus objektus
            FileLogger fl = new FileLogger(logPath);
            EmailSender es = new EmailSender();

            //eventam priskiriamos komandos
            manoBankas.OnMoneyTransfered += (s, e) => fl.HandleWriteTransaction(e);
            manoBankas.OnMoneyConversion += (s, e) => fl.HandleWriteTransaction(e);
            manoBankas.OnMoneyAdded += (s, e) => fl.HandleWriteTransaction(e);
            manoBankas.OnAnyTransaction += (s, e) => fl.HandleWriteTransaction(e);
            
            manoBankas.OnMoneyTransfered += (s, e) => es.HandlePrintTransaction(e);
            manoBankas.OnMoneyConversion += (s, e) => es.HandlePrintTransaction(e);
            manoBankas.OnMoneyAdded += (s, e) => es.HandlePrintTransaction(e);
            manoBankas.OnAnyTransaction += (s, e) => es.HandlePrintTransaction(e);
            
            ;

            //vykdomi veiksmai
            manoBankas.IdetiPinigus(300);
            Console.WriteLine();

            manoBankas.PervestiPinigus(256);
            Console.WriteLine();

            manoBankas.KeistiPinigus(0.6);

            Console.ReadKey();
        }

        static void TikrintiLoga(string path)   //jei randa pasilikusi sena log, ji istrina
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
