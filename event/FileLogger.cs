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
            
            
            if (File.Exists(_path)) //iesko failo pagal nurodyta kelia, jei randa, prideda nauja eilute
            {
                using(StreamWriter sw = File.AppendText(_path))
                {
                    sw.WriteLine(e);
                }
            }
            else            //neradus failo, sukuria nauja ir prideda prie jo eilute
            {
                using(StreamWriter sw = File.CreateText(_path))
                {
                    sw.WriteLine(e);
                }
            }
        }
    }
}
