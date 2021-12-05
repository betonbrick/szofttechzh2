using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Model
{
    public class loginUser
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public loginUser()
        {

        }

        public loginUser(string username, string pwd) 
        {
            Username = username;
            Password = pwd;
        }

        public bool checkEntries() 
        {
            if (Username == "user" && Password == "digi")
            {
                return true;
            }
            else if (Username == "" || Password =="")
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
