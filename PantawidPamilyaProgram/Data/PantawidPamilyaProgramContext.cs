using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PantawidPamilyaProgram.Models;

namespace PantawidPamilyaProgram.Data
{
    public class PantawidPamilyaProgramContext : DbContext
    {
        public PantawidPamilyaProgramContext (DbContextOptions<PantawidPamilyaProgramContext> options)
            : base(options)
        {
        }

        public DbSet<PantawidPamilyaProgram.Models.Pppp>? Pppp { get; set; }
    }
}
