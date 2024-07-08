using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseConnect
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("tbl_QLHieuThuocEntities")
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
