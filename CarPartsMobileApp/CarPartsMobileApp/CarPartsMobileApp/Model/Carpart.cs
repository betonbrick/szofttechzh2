using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Model
{
   public class Carpart
    {
        public int PartsId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string PictureUrl { get; set; }

        public Carpart()
        {

        }

        public Carpart(int partsid, string name, int price, string brand, string picsurl) 
        {
            PartsId = partsid;
            Name = name;
            Price = price;
            Brand = brand;
            PictureUrl = picsurl;
        }

    }

}
