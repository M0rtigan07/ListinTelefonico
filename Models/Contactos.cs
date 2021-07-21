using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListinTelefonico.Models
{
    [Index(nameof(telefono), IsUnique = true)]
    public class Contactos
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public int telefono { get; set; }
    }
}
