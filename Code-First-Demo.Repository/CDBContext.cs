using Code_First_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First_Demo.Repository
{
    public class CDBContext : DbContext
    {
        public CDBContext() : base("StringDBContext")
        {
        }
        public DbSet<MyFirstTable> MyFirstTable { get; set; }
    }
}
