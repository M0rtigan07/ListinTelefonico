using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListinTelefonico.Models;

namespace ListinTelefonico.Data
{
    public class ListinTelefonicoContext : DbContext
    {
        public ListinTelefonicoContext (DbContextOptions<ListinTelefonicoContext> options)
            : base(options)
        {
        }

        public DbSet<ListinTelefonico.Models.Contactos> Contacto { get; set; }
    }
}
