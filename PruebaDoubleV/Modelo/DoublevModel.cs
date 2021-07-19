using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{
   

        public class DoublevModel : DbContext
        {
            public DoublevModel() : base(GetOptions("server=localhost;database=doublev;User Id=sa;Password=Sql12345$;"))
        {
            }

            public DbSet<Ticket> Tickets { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

    }

}

