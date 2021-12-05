using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Model
{
    public class Login
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        

        public Login(string usrnm, string pwd)
        {
            UserName = usrnm;
            Password = pwd;
        }

        public Login()
        {

        }

        public bool entriesCheck() 
        {
            if (UserName == null || Password == null)
            {
                return false;
            }
            else if (UserName == "" || Password == "") 
            {
                return false;
            }
            else 
            {
                return true;
            }
        }
    }
}
