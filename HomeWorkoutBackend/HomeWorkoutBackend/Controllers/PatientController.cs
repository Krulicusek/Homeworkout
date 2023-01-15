using homeWorkOutApi.Net6._0.Data;
using HomeWorkoutModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPut]
        [Route("SetPhysiotherapists")]
        public async Task SetPhysiotherapists(int userId, int psychoId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            user.PhysioId = psychoId;
            _context.Update(user);
            _context.SaveChanges();
        }

        [HttpGet]
        [Route("AssignedPsycho")]
        public IActionResult AssignedPsycho(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user.PhysioId == null)
                return NotFound();
            return Ok();
        }
    }
}