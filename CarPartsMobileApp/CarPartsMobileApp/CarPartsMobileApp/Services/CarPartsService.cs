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
        public ObservableCollection<CarPartsModel> CarParts { get; set; }
        public CarPartsService()
        {
            CarParts = new ObservableCollection<CarPartsModel>();
        }
        public void InitCarpartsService()
        {
            CarParts.Add(new CarPartsModel(1, "Brake Disc", 100000, "TRW", "part.png"));
            CarParts.Add(new CarPartsModel(2, "Lamp", 500000, "Hella", "part.png"));
            CarParts.Add(new CarPartsModel(3,"Tire", 50000, "TOYO", "part.png"));
            CarParts.Add(new CarPartsModel(4, "Valami", 122222, "Akarmi", "part.png"));
        }

        public async Task<ObservableCollection<CarPartsModel>> GetCarPartsAsync(string inquiry)
        {
            Thread.Sleep(2300);

            if (inquiry != "")
            {
                CarParts.Clear();
                InitCarpartsService();
                List<CarPartsModel> carparts = CarParts.Where(cp => cp.Brand.ToLower().Contains(inquiry.ToLower()) || cp.Name.ToLower().Contains(inquiry.ToLower())).ToList();

                CarParts.Clear();
                foreach (CarPartsModel carpart in carparts)
                {
                    CarParts.Add(carpart);
                }
            }
            else
                InitCarpartsService();

            return await Task.FromResult(CarParts);
        }

        public async Task<bool> AddPartAsync(CarPartsModel carparts) 
        {
            CarParts.Add(carparts);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePartAsync(CarPartsModel carparts) 
        {
            CarPartsModel carpartsToEdit = CarParts.Where(cp => cp.PartsId == carparts.PartsId).FirstOrDefault();
            int newInd = CarParts.IndexOf(carpartsToEdit);
            CarParts.Remove(carpartsToEdit);
            CarParts.Add(carparts);
            int oldInd = CarParts.IndexOf(carparts);
            CarParts.Move(oldInd, newInd);

            return await Task.FromResult(true);
        }
    }
}
