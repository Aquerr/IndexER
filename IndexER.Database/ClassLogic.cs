using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IndexER.Logic.Entities;

namespace IndexER.Database
{
    public class ClassLogic
    {
        //TODO:Refactor this file.

        private readonly IDatabaseHelper _databaseHelper;
   //     private readonly DataContext _dataContext;

        public ClassLogic()
        {
          _databaseHelper = new DatabaseHelper();
      //     _dataContext = new DataContext(_databaseHelper.GetConnectionString());   
        }

        public async Task<List<Class>> GetClassesAsync()
        {
            //var classes = new List<Class>();
            //
            //Table<Class> table = _dataContext.GetTable<Class>();
            //
            //classes = table.AsEnumerable().ToList();

            string query = "select * from Class";

         //   SqlConnection connection = new SqlConnection(@"Data Source=AQUERR-LAPTOP;Initial Catalog=IndexERDB;Integrated Security=True");
         SqlConnection connection = new SqlConnection(_databaseHelper.GetConnectionString());
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            connection.Close();
            da.Dispose();

            List<Class> classes = new List<Class>();

            classes = (from DataRow row in dataTable.Rows

                select new Class
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString()
                }).ToList();

            return classes;
        }

     //
     //  [Table(Name = "Class")]
     //  public class Class
     //  {
     //      private string _classId;
     //
     //      [Column(IsPrimaryKey = true, Storage = "_ClassId")]
     //      public string ClassId
     //      {
     //          get { return this._classId; }
     //          set { this._classId = value; }
     //      }
     //
     //      private string _name;
     //
     //      [Column(Storage = "_Name")]
     //      public string Name
     //      {
     //          get { return this._name; }
     //          set { this._name = value; }
     //      }
     //  }

    }
}
