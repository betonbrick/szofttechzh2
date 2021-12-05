using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Model
{
   public class CarPartsModel
    {
        public int PartsId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string PictureUrl { get; set; }

        public CarPartsModel()
        {

        }
        public CarPartsModel(int partsId ,string name, int price, string brand, string picsUrl)
        {
            PartsId = partsId;
            Name = name;
            Price = price;
            Brand = brand;
            PictureUrl = picsUrl;
            
        }
    }
}
