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
        [HttpGet(Name = "GetAllExerciseModels")]
        public IEnumerable<ExerciseModel> GetAll()
        {
            return _context.ExerciseModel.ToArray();     
        }
        [HttpGet("{id}",Name = "GetExerciseModel")]
        public ExerciseModel Get(int id)
        {
            return _context.ExerciseModel.Find(id);           
        }
            
        [HttpPost(Name = "PostExerciseModel")]
        public void Post(ExerciseModel exerciseModel)
        {
            _context.ExerciseModel.Add(exerciseModel);
            _context.SaveChanges(); 
        }

        [HttpDelete("{id}", Name = "DeleteExerciseModel")]
        public void Delete(int id)
        {
            _context.ExerciseModel.Remove(Get(id));
            _context.SaveChanges();
        }
        [HttpPut("{id}", Name = "PutExerciseModel")]
        public void Put(int id,[FromBody]ExerciseModel exerciseModel)
        {
            _context.ExerciseModel.Update(exerciseModel);
            _context.SaveChanges();
        }

    }
}
