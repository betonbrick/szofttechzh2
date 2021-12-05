using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPartsMobileApp.Data
{
   public interface ISQLite
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
