using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseConnect
{
    public class SqlAuthenticationDAL
    {
        public bool TestConnection(string serverName, string username, string password)
        {
            try
            {
                var connectionString = $"data source={serverName};initial catalog=tbl_QLHieuThuoc;user id={username};password={password};MultipleActiveResultSets=True;App=EntityFramework";
                using (var db = new DatabaseContext())
                {
                    db.Database.Connection.ConnectionString = connectionString;
                    db.Database.Connection.Open();
                    db.Database.Connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
