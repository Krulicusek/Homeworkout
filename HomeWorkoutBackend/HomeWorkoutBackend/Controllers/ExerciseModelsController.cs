using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkoutBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseModelsController : ControllerBase
    {
        private readonly HomeWorkoutContext _context;
        private readonly ILogger<ExerciseModelsController> _logger;

        public ExerciseModelsController(HomeWorkoutContext context, ILogger<ExerciseModelsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet(Name = "GetExerciseModel")]
        public IEnumerable<ExerciseModel> Get()
        {
            return _context.ExerciseModel.ToArray();
        }

    }
}
