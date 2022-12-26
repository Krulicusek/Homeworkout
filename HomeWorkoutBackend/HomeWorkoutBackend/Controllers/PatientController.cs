using homeWorkOutApi.Net6._0.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeWorkoutBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HomeWorkoutContext _context;
        private readonly ILogger<HomeworkSequenceController> _logger;
        public PatientController(HomeWorkoutContext context, ILogger<HomeworkSequenceController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet("{id}", Name = "GetPatients")]
        public List<User> GetPatients(int id)
        {
            return _context.Users.Where(x=>x.PhysioId == id).ToList();
        }
        [HttpGet(Name = "GetPhysiotherapists")]
        public List<User> GetPhysiotherapists()
        {
            return _context.Users.Where(x => x.Role == "physiotherapist").ToList();
        }
    }
}