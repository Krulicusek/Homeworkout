using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
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

        [HttpGet("GetPatients/{id}", Name = "GetPatients")]
        public List<UserBasicDetail> GetPatients(int id)
        {
            var userList  = _context.Users.Where(x => x.PhysioId == id).ToList();
            List<UserBasicDetail> basicDetails= new List<UserBasicDetail>();
            foreach (var user in userList)
            {
                var userBasic = new UserBasicDetail(user);
                basicDetails.Add(userBasic);
            }
            return basicDetails;
        }

        [HttpGet("GetPhysiotherapists", Name = "GetPhysiotherapists")]
        public List<UserBasicDetail> GetPhysiotherapists()
        {
            var userList = _context.Users.Where(x => x.Role == "physiotherapist").ToList();
            List<UserBasicDetail> basicDetails = new List<UserBasicDetail>();
            foreach (var user in userList)
            {
                var userBasic = new UserBasicDetail(user);
                basicDetails.Add(userBasic);
            }
            return basicDetails;
        }
    }
}