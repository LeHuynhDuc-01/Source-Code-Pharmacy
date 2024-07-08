using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseConnect
{
    public class WindowsAuthenticationDAL
    {
        public bool TestConnection(string serverName)
        {
            try
            {
                var connectionString = $"data source={serverName};initial catalog=tbl_QLHieuThuoc;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
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
