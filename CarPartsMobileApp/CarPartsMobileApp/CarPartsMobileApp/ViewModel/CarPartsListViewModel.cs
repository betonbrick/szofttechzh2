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
       

        public ICommand srchcommand => new Command<string>(loadAllCarparts); //TODO //FIXME
        public ObservableCollection<Carpart> Carparts { get; set; }

        public string Name { get; set; }

        public string SelectedPart { get; set; }

        public bool IsBusy { get; set; }

        private CarPartsService carPartsService;

        public void loadAllCarparts(string inquiry)
        {
            IsBusy = true;

            Task.Run(async () =>
            {
                Carparts = await carPartsService.GetCarPartsAsync(inquiry);
                IsBusy = false;
            });
        }

        public CarPartsListViewModel()
        {
            carPartsService = new CarPartsService();
            loadAllCarparts(string.Empty);

            MessagingCenter.Subscribe<AddOrEditCarpartsPage, Carpart>(this, "AddOrEditCarParts",(page,carparts)=>
            {
                if (carparts.PartsId==0)
                {
                    carparts.PartsId = Carparts.Count + 1;
                    Carparts.Add(carparts);
                }
                else
                {
                    Carpart carpartsEditor = Carparts.Where(cp => cp.PartsId == carparts.PartsId).FirstOrDefault();

                    int newInd = Carparts.IndexOf(carpartsEditor);
                    Carparts.Remove(carpartsEditor);
                    Carparts.Add(carparts);
                    int oldInd = Carparts.IndexOf(carparts);

                    Carparts.Move(oldInd, newInd);

                }
            });
        }

        

    }
}
