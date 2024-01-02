using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InfoKiosk.Modules.Survey.Models
{
    public  class SurveyDbContext : DbContext
    {
        public DbSet<Ankieta> Ankiety { get; set; }
        public DbSet<Pytanie> Pytania { get; set; }

        public DbSet<Odpowiedz> Odopowiedzi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Pytanie>()
                .HasOne(x => x.Ankieta)
                .WithMany(x => x.Pytania)
                .HasForeignKey(x => x.IdAnkiety);

            modelBuilder.Entity<Odpowiedz>()
               .HasOne(x => x.Pytanie)
               .WithMany(x => x.Odpowiedzi)
               .HasForeignKey(x => x.IdPytania);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-81JH9P4\\SQLEXPRESS;Initial Catalog=InfoKioskAnkiety;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
