using DAL.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthenticationBLL
    {
        private readonly WindowsAuthenticationDAL _windowsAuthenticationDAL;
        private readonly SqlAuthenticationDAL _sqlAuthenticationDAL;

        public AuthenticationBLL()
        {
            _windowsAuthenticationDAL = new WindowsAuthenticationDAL();
            _sqlAuthenticationDAL = new SqlAuthenticationDAL();
        }

        public bool TestWindowsAuthenticationConnection(string serverName)
        {
            try
            {
                return _windowsAuthenticationDAL.TestConnection(serverName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool TestSqlAuthenticationConnection(string serverName, string username, string password)
        {
            try
            {
                return _sqlAuthenticationDAL.TestConnection(serverName, username, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
