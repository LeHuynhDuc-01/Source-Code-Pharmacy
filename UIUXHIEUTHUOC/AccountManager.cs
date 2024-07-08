using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIUXHIEUTHUOC
{
    internal class AccountManager
    {
        private static AccountManager _instance;
        public static AccountManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountManager();
                }
                return _instance;
            }
        }
        private string _TenDuocSi;
        private int _MaDuocSi;
        private string _TenDangNhap;
        public void Login(string username, string TenDuocSi, int MaDuocSi)
        {
            this._TenDuocSi = TenDuocSi;
            this._MaDuocSi = MaDuocSi;
            this._TenDangNhap = username;
        }

        public string GetUsername()
        {
            return this._TenDangNhap;
        }

        public string GetFullName()
        {
            return this._TenDuocSi;
        }
        public int GetID()
        {
            return this._MaDuocSi;
        }
    }
}
