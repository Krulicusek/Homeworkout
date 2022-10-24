using homeWorkOutApi.Net6._0.Data;
using HomeWorkOutApi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkoutBackend.Controllers
{
    public class ExerciseModelsController : Controller
    {
        private readonly homeWorkOutApiNet6_0Context _context;

        public ExerciseModelsController(homeWorkOutApiNet6_0Context context)
        {
            _context = context;
        }

        public IEnumerable<ExerciseModel> Get()
        {
            return _context.ExerciseModel.ToArray();
        }

    }
}
