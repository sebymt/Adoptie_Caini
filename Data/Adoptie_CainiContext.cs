using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adoptie_Caini.Models;

namespace Adoptie_Caini.Data
{
    public class Adoptie_CainiContext : DbContext
    {
        public Adoptie_CainiContext (DbContextOptions<Adoptie_CainiContext> options)
            : base(options)
        {
        }

        public DbSet<Adoptie_Caini.Models.Dog> Dog { get; set; }

        public DbSet<Adoptie_Caini.Models.Breed> Breed { get; set; }

        public DbSet<Adoptie_Caini.Models.Color> Color { get; set; }
    }
}
