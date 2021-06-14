using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuestNine.Models
{
    public class DragonQuestDbContext : DbContext
    {
        public DragonQuestDbContext(DbContextOptions<DragonQuestDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Accolade> Accolades { get; set; }
        public virtual DbSet<AccoladeCategory> AccoladeCategories {get; set; }
        public virtual DbSet<AccoladeType> AccoladeTypes { get; set; }
    }
}
