
using HomeWorkoutModels.Models;
using Microsoft.EntityFrameworkCore;
namespace homeWorkOutApi.Net6._0.Data
{
    public class HomeWorkoutContext : DbContext
    {
        private readonly string _connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=krulicusek_HomeWorkout;User Id=krulicusek_HomeWorkout;Password=HomeWorkout123;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<ExerciseModel> ExerciseModel { get; set; }
        public DbSet<HomeworkSequenceModel> HomeworkSequenceModel { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
