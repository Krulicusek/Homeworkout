using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeWorkOutApi.NetCore.Models;

namespace homeWorkOutApi.Net6._0.Data
{
    public class homeWorkOutApiNet6_0Context : DbContext
    {
        public homeWorkOutApiNet6_0Context (DbContextOptions<homeWorkOutApiNet6_0Context> options)
            : base(options)
        {
        }

        public DbSet<HomeWorkOutApi.NetCore.Models.ExerciseModel> ExerciseModel { get; set; }
    }
}
