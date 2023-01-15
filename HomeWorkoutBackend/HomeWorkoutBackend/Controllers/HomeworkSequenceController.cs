using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkoutBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworkSequenceController : ControllerBase
    {
        private readonly HomeWorkoutContext _context;
        private readonly ILogger<HomeworkSequenceController> _logger;
        public HomeworkSequenceController(HomeWorkoutContext context, ILogger<HomeworkSequenceController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllHomeworkSequenceModels")]
        public IEnumerable<HomeworkSequenceModel> GetAll()
        {
            return _context.HomeworkSequenceModel
                .Include(x => x.HomeworkICollection.OrderBy(x => x.PlaceInSequence))
                .ToArray();
        }

        [HttpGet("{id}", Name = "GetHomeworkSequenceById")]
        public HomeworkSequenceModel GetHomeworkSequenceById(int id)
        {
            return _context.HomeworkSequenceModel
                .Include(x => x.HomeworkICollection.OrderBy(x => x.PlaceInSequence))
                .FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("userId/{userId}", Name = "GetHomeworkSequenceByUserId")]
        public HomeworkSequenceModel GetHomeworkSequenceByUserId(int userId)
        {
            return _context.HomeworkSequenceModel.Include(x => x.HomeworkICollection.OrderBy(x => x.PlaceInSequence))
                .OrderBy(x => x.Id).LastOrDefault(x => x.UserId == userId);
        }

        [HttpPost(Name = "PostHomeworkSequence")]
        public void Post(HomeworkSequenceModel homeworkSequence)
        {
            _context.HomeworkSequenceModel.Add(homeworkSequence);
            _context.SaveChanges();
        }

        [HttpDelete("{id}", Name = "DeleteHomeworkSequence")]
        public void Delete(int id)
        {
            _context.HomeworkSequenceModel.Remove(GetHomeworkSequenceById(id));
            _context.SaveChanges();
        }

        [HttpPut("{id}", Name = "PutHomeworkSequence")]
        public void Put(int id, HomeworkSequenceModel homeworkSequence)
        {
            _context.HomeworkSequenceModel.Update(homeworkSequence);
            _context.SaveChanges();
        }
    }
}
