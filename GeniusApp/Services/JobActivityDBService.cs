using GeniusApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusApp.Services
{
    public class JobActivityDBService
    {

        private readonly SQLiteConnection _dbConnection;
        public JobActivityDBService()
        {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GeniusDB.db3");
            _dbConnection = new SQLiteConnection(dbPath);
            _dbConnection.CreateTable<JobActivityModel>();

        }

        public List<JobActivityModel> GetAllJobActivities()
        {
            var res = _dbConnection.Table<JobActivityModel>().ToList();
            return res;
        }

        public int InsertJobActivity(JobActivityModel obj)
        {
               return _dbConnection.Insert(obj);          
          
        }

        public bool DropAndCreateTableJobActivity()
        {
            _dbConnection.DropTable<JobActivityModel>();
            _dbConnection.CreateTable<JobActivityModel>();
            return false;
        }

        public int UpdateJobActivity(JobActivityModel obj)
        {
            return _dbConnection.Update(obj);
        }

        public int DeleteJobActivity(JobActivityModel obj)
        {
            return _dbConnection.Delete(obj);
        }
    }
}