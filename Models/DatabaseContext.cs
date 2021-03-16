using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options ) : base (options)
        { }

        public DbSet<Timeslot> Timeslots { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
