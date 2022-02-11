using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stomatology.Areas.Identity.Data;
using Stomatology.Areas.Moderator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Data
{
    public class StomatologyDbContext : IdentityDbContext<ApplicationUser>
    {
        public StomatologyDbContext(DbContextOptions<StomatologyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Record> RecordsTB { get; set; }
        public DbSet<Dentist> DentistsTB { get; set; }
        public DbSet<Procedure> ProceduresTB { get; set; }

    }
}
