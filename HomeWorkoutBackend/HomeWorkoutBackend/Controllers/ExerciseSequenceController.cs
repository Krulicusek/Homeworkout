using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkoutBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseSequenceController : ControllerBase
    {
        private readonly HomeWorkoutContext _context;
        private readonly ILogger<ExerciseSequenceController> _logger;
        public ExerciseSequenceController(HomeWorkoutContext context, ILogger<ExerciseSequenceController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet(Name = "GetAllExerciseSequenceModels")]
        public IEnumerable<ExerciseSequenceModel> GetAll()
        {
            return _context.ExerciseSequenceModel.ToArray();
        }
        //[HttpGet("{id}", Name = "GetExerciseSequence")]
        //public ExerciseSequenceModel Get(int id)
        //{
        //    return _context.ExerciseSequenceModel.Include(x => x.Exercises).
        //}

        [HttpPost(Name = "PostExerciseSequence")]
        public void Post(ExerciseSequenceModel exerciseSequence)
        {
            _context.ExerciseSequenceModel.Add(exerciseSequence);
            _context.SaveChanges();
        }
        //[HttpDelete("{id}", Name = "DeleteExerciseSequence")]
        //public void Delete(int id)
        //{
        //    _context.ExerciseSequenceModel.Remove(Get(id));
        //    _context.SaveChanges();
        //}
        [HttpPut("{id}", Name = "PutExerciseSequence")]
        public void Put(int id, ExerciseSequenceModel exerciseSequence)
        {
            _context.ExerciseSequenceModel.Update(exerciseSequence);
            _context.SaveChanges();
        }
    }
}
