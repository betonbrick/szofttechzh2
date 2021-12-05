using CarPartsMobileApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CarPartsMobileApp.Data
{
    public class TokenzDBController
    {
        static object locker = new object();
        SQLiteConnection sqlitedb;

        public TokenzDBController() 
        {
            sqlitedb = DependencyService.Get<ISQLite>().GetSQLiteConnection();
            sqlitedb.CreateTable<Tokenz>();
        }

        public Tokenz GetTokenz() 
        
        {
            lock (locker) 
            {
                if (sqlitedb.Table<Tokenz>().Count()==0)
                {
                    return null;
                }
                else
                {
                    return sqlitedb.Table<Tokenz>().First();
                }
            }
        }

        public int SaveTokenz(Tokenz tokenz) 
        {
            lock (locker) 
            {
                if (tokenz.Id !=0)
                {
                    sqlitedb.Update(tokenz);
                    return tokenz.Id;
                }
                else
                {
                    return sqlitedb.Insert(tokenz);
                }
            }
        }
    }
}
