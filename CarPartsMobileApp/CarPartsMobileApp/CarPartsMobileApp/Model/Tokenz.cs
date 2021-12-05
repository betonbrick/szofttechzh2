using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Model
{
    public class Tokenz
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string accToken { get; set; }
        public string errorMsg { get; set; }
        public int expireIn { get; set; }
        public DateTime expireDt { get; set; }
        public Tokenz()
        {

        }
    }
}
