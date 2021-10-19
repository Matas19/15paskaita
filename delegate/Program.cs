using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @delegate
{
    public delegate void ManoDelegatas(int m1, int m2);

    class Program
    {

        private static ManoDelegatas _DarytiVeiksmus;
        static void Main(string[] args)
        {
            //priskiriama MyMultiply funkcija
            _DarytiVeiksmus = MyMultiply;
            _DarytiVeiksmus(3, 5);

            Console.WriteLine();

            ////pridedu mysum delegatui
            _DarytiVeiksmus += MySum;
            _DarytiVeiksmus(3, 5);

            Console.WriteLine();

            //atumu MyMultiply
            _DarytiVeiksmus -= MyMultiply;
            _DarytiVeiksmus(3, 5);

            Console.ReadKey();
        }

        static void MyMultiply(int m1, int m2)
        {
            int sandauga = m1 * m2;
            Console.WriteLine(sandauga);
        }

        static void MySum(int m1, int m2)
        {
            int suma = m1 + m2;
            Console.WriteLine(suma);
        }
    }
}
