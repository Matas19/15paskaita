using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @event
{
    //Klase skirta duomenu ivedimui i faila
    class FileLogger
    {
        private string _path;
        public FileLogger(string path) 
        {
            _path = path;
        }

        public void HandleWriteTransaction(string e)
        {
            
            //string duomenys = $"Banko saskaite {bank.pavadinimas} pinigu kiekis pakito i {bank.likutis}";
            if (File.Exists(_path))
            {
                using(StreamWriter sw = File.AppendText(_path))
                {
                    sw.WriteLine(e);
                }
            }
            else
            {
                using(StreamWriter sw = File.CreateText(_path))
                {
                    sw.WriteLine(e);
                }
            }
        }
    }
}
