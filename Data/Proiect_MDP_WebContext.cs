using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_MDP_Web.Models;

namespace Proiect_MDP_Web.Data
{
    public class Proiect_MDP_WebContext : DbContext
    {
        public Proiect_MDP_WebContext (DbContextOptions<Proiect_MDP_WebContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_MDP_Web.Models.Racheta> Racheta { get; set; } = default!;

        public DbSet<Proiect_MDP_Web.Models.Magazin>? Magazin { get; set; }

        public DbSet<Proiect_MDP_Web.Models.Firma>? Firma { get; set; }

        public DbSet<Proiect_MDP_Web.Models.Categorie>? Categorie { get; set; }

        public DbSet<Proiect_MDP_Web.Models.Client>? Client { get; set; }

        public DbSet<Proiect_MDP_Web.Models.Serviciu>? Serviciu { get; set; }
    }
}
