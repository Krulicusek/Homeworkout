using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkoutModels.Models
{
    public class UserBasicDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string PhysioId { get; set; }
        public UserBasicDetail() { }
        public UserBasicDetail(User user)
        {
            this.Id = user.Id.ToString();
            this.Name = user.FirstName;
            this.Surname = user.LastName;
            this.Email = user.Email;
            this.Role = user.Role;
            this.PhysioId= user.PhysioId.ToString();
        }
    }
}
