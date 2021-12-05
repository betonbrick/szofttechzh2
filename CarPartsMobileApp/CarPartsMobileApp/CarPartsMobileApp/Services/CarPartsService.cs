using CarPartsMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarPartsMobileApp.Services
{
    public class CarPartsService
    {
        public ObservableCollection<Carpart> Carparts { get; set; }
        public CarPartsService()
        {
            Carparts = new ObservableCollection<Carpart>();
            
        }
        public void InitCarpartsService()
        {
            Carparts.Add(new Carpart(1, "Brake Disc", 100000, "Trw", "part.png"));
            Carparts.Add(new Carpart(2, "Lamp", 500000, "Hella", "part.png"));
            Carparts.Add(new Carpart(3,"Tire", 50000, "Toyo", "part.png"));
            Carparts.Add(new Carpart(4, "Valami", 122222, "Akarmi", "part.png"));
            Carparts.Add(new Carpart(5, "Akarmi", 23444, "Nemtudom", "part.png"));
        }

        public async Task<ObservableCollection<Carpart>> GetCarPartsAsync(string inquiry)
        {
            Thread.Sleep(2500);

            if (inquiry != "")
            {
                Carparts.Clear();
                InitCarpartsService();
                List<Carpart> carparts = Carparts.Where(cp => cp.Brand.ToLower().Contains(inquiry.ToLower()) || cp.Name.ToLower().Contains(inquiry.ToLower())).ToList();

                Carparts.Clear();
                foreach (Carpart carpart in carparts)
                {
                    Carparts.Add(carpart);
                }
            }
            else
            {
                InitCarpartsService();
            }
                

            return await Task.FromResult(Carparts);
        }

        public async Task<bool> AddPartAsync(Carpart carparts) 
        {
            Carparts.Add(carparts);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePartAsync(Carpart carparts) 
        {
            Carpart carpartsToEdit = Carparts.Where(cp => cp.PartsId == carparts.PartsId).FirstOrDefault();
            int newInd = Carparts.IndexOf(carpartsToEdit);
            Carparts.Remove(carpartsToEdit);
            Carparts.Add(carparts);
            int oldInd = Carparts.IndexOf(carparts);
            Carparts.Move(oldInd, newInd);

            return await Task.FromResult(true);
        }
    }
}
