using CarPartsMobileApp.Model;
using CarPartsMobileApp.Services;
using CarPartsMobileApp.View;
using CarPartsMobileApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarPartsMobileApp.ViewModel
{
    class CarPartsListViewModel : BaseViewModel
    {
        public ObservableCollection<CarPartsModel> CarParts { get; set; }

        public ICommand srchcommand => new Command<string>(loadAllCarparts); //TODO //FIXME

        public string Name { get; set; }

        public string SelectedPart { get; set; }

        public bool IsBusy { get; set; }

        private CarPartsService carPartsService;

        public CarPartsListViewModel()
        {
            carPartsService = new CarPartsService();
            loadAllCarparts(string.Empty);

            MessagingCenter.Subscribe<AddOrEditCarpartsPage, CarPartsModel>(this, "AddOrEditPart",(page,carparts)=>
            {
                if (carparts.PartsId==0)
                {
                    carparts.PartsId = CarParts.Count + 1;
                    CarParts.Add(carparts);
                }
                else
                {
                    CarPartsModel carpartsEditor = CarParts.Where(ped => ped.PartsId == carparts.PartsId).FirstOrDefault();

                    int newInd = CarParts.IndexOf(carpartsEditor);
                    CarParts.Remove(carpartsEditor);
                    CarParts.Add(carparts);
                    int oldInd = CarParts.IndexOf(carparts);

                    CarParts.Move(oldInd, newInd);

                }
            });
        }

        public void loadAllCarparts(string inquiry) 
        {
            IsBusy = true;

            Task.Run(async () =>
           {
               CarParts = await carPartsService.GetCarPartsAsync(inquiry);
           });
        }

    }
}
