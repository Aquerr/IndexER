using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IndexER.Database
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["IndexER.DataBase.IndexERDB"].ConnectionString;

            if(string.IsNullOrEmpty(connectionString)) throw new ConfigurationErrorsException("Nie ma bazy danych nazwanej" + connectionString + ".");

            return connectionString;
        }

        public void Execute(Action action)
        {
            throw new NotImplementedException();
        }
    }
}
