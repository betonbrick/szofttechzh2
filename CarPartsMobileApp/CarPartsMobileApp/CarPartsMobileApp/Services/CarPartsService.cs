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
            CarParts.Add(new CarPartsModel(1,11233, "Brake Disc", 4, 100000, "TRW", "part.jpg"));
            CarParts.Add(new CarPartsModel(2,41246, "Lamp", 2, 500000, "Hella", "part.jpg"));
            CarParts.Add(new CarPartsModel(2,71243, "Tire", 4, 50000, "TOYO", "part.jpg"));
        }

        public async Task<ObservableCollection<CarPartsModel>> GetCarPartsAsync(string inquiry)
        {
            Thread.Sleep(3000);

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
