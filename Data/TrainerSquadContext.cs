using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainerSquad.Models;

namespace TrainerSquad.Data
{
    public class TrainerSquadContext : DbContext
    {
        public TrainerSquadContext (DbContextOptions<TrainerSquadContext> options)
            : base(options)
        {
        }

        public DbSet<TrainerSquad.Models.Personal> Personal { get; set; } = default!;

        public DbSet<TrainerSquad.Models.Equipment>? Equipment { get; set; }

        public DbSet<TrainerSquad.Models.Client>? Client { get; set; }

        public DbSet<TrainerSquad.Models.Payment>? Payment { get; set; }

        public DbSet<TrainerSquad.Models.PhysicalAssessment>? PhysicalAssessment { get; set; }

        public DbSet<TrainerSquad.Models.Schedule>? Schedule { get; set; }

        public DbSet<TrainerSquad.Models.Training>? Training { get; set; }
    }
}
