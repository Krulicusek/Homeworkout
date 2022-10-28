using HomeWorkOutApi.NetCore.Models;
using Microsoft.EntityFrameworkCore;
namespace homeWorkOutApi.Net6._0.Data
{
    public class HomeWorkoutContext : DbContext
    {
        public HomeWorkoutContext (DbContextOptions<HomeWorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<ExerciseModel> ExerciseModel { get; set; }
    }
}
