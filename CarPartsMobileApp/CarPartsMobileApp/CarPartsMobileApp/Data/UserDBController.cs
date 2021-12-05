using CarPartsMobileApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CarPartsMobileApp.Data
{
    public class UserDBController
    {
        static object locker = new object();

        SQLiteConnection sqlitedb;

        public UserDBController()
        {
            sqlitedb = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            sqlitedb.CreateTable<loginUser>();
        }

        public loginUser GetUserLoginData()
        {
            lock (locker)
            {
                if (sqlitedb.Table<loginUser>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return sqlitedb.Table<loginUser>().First();
                }


            }
        }
        public int SaveUserLoginData(loginUser loginuser)
        {
            lock (locker)
            {
                if (loginuser.Id != 0)
                {
                    sqlitedb.Update(loginuser);
                    return loginuser.Id;
                }
                else
                {
                    return sqlitedb.Insert(loginuser);
                }
            }
        }
        public int DeleUserLoginData(int id) 
        {
            lock (locker) 
            {
                return sqlitedb.Delete<loginUser>(id);
            }
        }
    }
}
