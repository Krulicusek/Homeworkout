
using HomeWorkoutModels.Models;
using Microsoft.EntityFrameworkCore;
namespace homeWorkOutApi.Net6._0.Data
{
    public class HomeWorkoutContext : DbContext
    {
        private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=homeWokrOutDB;Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<ExerciseModel> ExerciseModel { get; set; }
        public DbSet<HomeworkSequenceModel> HomeworkSequenceModel { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
