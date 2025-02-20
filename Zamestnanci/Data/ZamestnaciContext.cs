using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZamestnanciManagement.Model;

namespace Zamestnanci.Data
{
    public class ZamestnaciContext : DbContext
    {
        public DbSet<Zamestnanec> Zamestnanci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ks\BARTASZAHRADA;Initial Catalog=Zamestnanci;Integrated Security=True;Trust Server Certificate=True");
        }

    }
}
