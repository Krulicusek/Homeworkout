using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;

namespace HomeWorkoutBackend
{
    public class Seeder
    {
        private readonly HomeWorkoutContext _dbContext;

        public Seeder(HomeWorkoutContext homeWorkOutContext)
        {
            _dbContext = homeWorkOutContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name= "User",
                },
                new Role()
                {
                    Name="Employee",
                },
                new Role()
                {
                    Name="Admin",
                }

            };
            return roles;
        }
    }
}
