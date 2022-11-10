using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
using Microsoft.AspNetCore.Http;
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
            return _context.HomeworkSequenceModel.Include(x => x.HomeworkICollection).ThenInclude(x => x.Exercise).ToArray();
        }
        [HttpGet("{id}", Name = "GetHomeworkSequence")]
        public HomeworkSequenceModel Get(int id)
        {
            return _context.HomeworkSequenceModel
                .Include(x => x.HomeworkICollection)
                .ThenInclude(x => x.Exercise)
                .FirstOrDefault(x => x.Id == id);
        }

        [HttpPost(Name = "PostHomeworkSequence")]
        public void Post(HomeworkSequenceModel homeworkSequence)
        {
            _context.HomeworkSequenceModel.Add(homeworkSequence );
            _context.SaveChanges();
        }
        [HttpDelete("{id}", Name = "DeleteHomeworkSequence")]
        public void Delete(int id)
        {
            _context.HomeworkSequenceModel.Remove(Get(id));
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
