using Microsoft.EntityFrameworkCore;
using SULS.Models;

namespace SULS.Data
{
    public class SULSContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
            
            modelBuilder.Entity<Problem>()
                .HasKey(problem => problem.Id);
            
            modelBuilder.Entity<Submission>()
                 .HasKey(submission => submission.Id);

            modelBuilder.Entity<Submission>()
                .HasOne(submission => submission.User);

            modelBuilder.Entity<Submission>()
                .HasOne(submission => submission.Problem);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
