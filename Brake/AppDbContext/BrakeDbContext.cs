using Brake.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brake.AppDbContext
{
    public class BrakeDbContext:IdentityDbContext<IdentityUser>
    {
        public BrakeDbContext(DbContextOptions<BrakeDbContext> options):
            base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }



    }
}
