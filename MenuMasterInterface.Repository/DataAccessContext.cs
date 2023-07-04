using MenuMasterInterface.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuMasterInterface.Repository
{
    public class DataAccessContext:DbContext
    {
        public DataAccessContext()
            : base("name=DataAccess")
        { }
        public DbSet<MenuMaster> MenuMaster { get; set; }
    }
}
