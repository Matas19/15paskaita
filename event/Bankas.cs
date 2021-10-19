using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @event
{
    
    public class Bankas
    {
        
        public string pavadinimas { get; }
        public double likutis { get; private set; }

        public Bankas(string pav, double suma)
        {
            pavadinimas = pav;
            likutis = suma;

            //pridedamas bendro event kvietimas visiem specifiniam eventam
            OnMoneyTransfered += (sender, e) => OnAnyTransaction?.Invoke(sender, "Buvo atliktas veiksmas");
            OnMoneyAdded += (sender, e) => OnAnyTransaction?.Invoke(sender, "Buvo atliktas veiksmas");
            OnMoneyConversion += (sender, e) => OnAnyTransaction?.Invoke(sender, "Buvo atliktas veiksmas");
        }
        public  void PervestiPinigus(double suma)
        {
            likutis -= suma;
            //OnAnyTransaction?.Invoke(this, "buvo atliktas veiksmas");                 //perkelta i konstruktoriu
            OnMoneyTransfered?.Invoke(this, $"Jus isimete {suma}, likutis: {likutis}");
        }
        public  void IdetiPinigus(int suma)
        {
            likutis += suma;
            //OnAnyTransaction?.Invoke(this, "buvo atliktas veiksmas");                 //perkelta i konstruktoriu
            OnMoneyAdded?.Invoke(this, $"Jus idejote {suma}, likutis: {likutis}");
        }
        public void KeistiPinigus(double kursas)
        {
            likutis = likutis * kursas;
            //OnAnyTransaction?.Invoke(this, "buvo atliktas veiksmas");                 //perkelta i konstruktoriu
            OnMoneyConversion?.Invoke(this, $"Jus perkonvertavote savo santaupas, likutis {likutis}");
        }
        
        public event EventHandler<string> OnAnyTransaction;
        public event EventHandler<string> OnMoneyConversion;
        public event EventHandler<string> OnMoneyAdded;
        public event EventHandler<string> OnMoneyTransfered;


        }
}
