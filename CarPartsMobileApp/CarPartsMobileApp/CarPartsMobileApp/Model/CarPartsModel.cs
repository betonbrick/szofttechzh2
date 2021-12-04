using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Model
{
   public class CarPartsModel
    {
        public int PartsId { get; set; }
        public int ProdNum { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string PictureUrl { get; set; }

        public CarPartsModel()
        {

        }
        public CarPartsModel(int partsId ,int prodNum,string name,int qty, int price, string brand, string picsUrl)
        {

            ProdNum = prodNum;
            Name = name;
            Qty = qty;
            Price = price;
            Brand = brand;
            PictureUrl = picsUrl;
            PartsId = partsId;
        }
    }
}
