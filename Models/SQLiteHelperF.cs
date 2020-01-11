using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace FinalTest.Models
{
    public class SQLiteHelperF
    {
        private static SQLiteHelperF _instance;

        public SQLiteConnection SQLiteConnection { get; set; }

        private static string DatabaseName = "finalexamphonecontact.db";

        public static SQLiteHelperF CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new SQLiteHelperF();
            }
            return _instance;
        }

        public SQLiteHelperF()
        {
            SQLiteConnection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            CreatePhoneContactTable();
        }

        private void CreatePhoneContactTable()
        {
            var sql = @"Create table if not exists PhoneContacts (Id integer primary key AUTOINCREMENT, Name varchar(200), PhoneNumber varchar(50) UNIQUE)";
            using (var statement = SQLiteConnection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
