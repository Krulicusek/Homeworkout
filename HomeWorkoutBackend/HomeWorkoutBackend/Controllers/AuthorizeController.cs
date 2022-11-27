//using homeWorkOutApi.Net6.Data;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
                                                        //DEPRECIATED
//namespace HomeWorkoutBackend.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class AuthorizeController : ControllerBase
//    {
//        private readonly IConfiguration _configuration;

//        public AuthorizeController(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        [HttpGet("GetCurrentUser")]
//        public async Task<ActionResult<User>> GetCurrentUser()
//        {
//            User currentUser = new User();

//            if (User.Identity.IsAuthenticated)
//            {
//                currentUser.Username = User.FindFirstValue(ClaimTypes.Name);
//            }

//            return await Task.FromResult(currentUser);
//        }

//        [HttpGet("Logout")]
//        public async Task<ActionResult<String>> LogOutUser()
//        {
//            await HttpContext.SignOutAsync();
//            return "Success";
//        }

//        [HttpPost("login")]
//        public async Task<ActionResult<User>> Validate([FromBody] UsrPwd usrPwd)
//        {
//            AppSettings appSettings = new AppSettings(_configuration);
//            if (appSettings == null)
//            {
//                throw new Exception("AppSettings null");
//            }

//            bool? isTest = appSettings.IsTest;
            
//            if (!isTest.HasValue)
//            {
//                return null;
//            }

//            if (isTest == false)
//            {
//                List<string> testUsers = appSettings.TestUsers;

//                if (testUsers == null || testUsers.Count == 0)
//                {
//                    appSettings.GetTestUsers();
//                    testUsers = appSettings.TestUsers;
//                }

//                if (testUsers.Contains(usrPwd.Username) && appSettings.TestUsersPassword == usrPwd.Pwd)
//                {
//                    string role = string.Empty;

//                    if (usrPwd.Username == "Physiotherapist")
//                    {
//                        role = "Physio";
//                    }
//                    else if (usrPwd.Username == "Patient")
//                    {
//                        role = "Patient";
//                    }               
//                    else
//                    {
//                        return null;
//                    }

//                    User user = new User
//                    {
//                        Username = usrPwd.Username,
//                        Role = role,
//                    };
//                    var claim = new Claim(ClaimTypes.Name, usrPwd.Username);
//                    var claimsIdentity = new ClaimsIdentity(new[] { claim }, CookieAuthenticationDefaults.AuthenticationScheme);
//                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//                    await HttpContext.SignInAsync(claimsPrincipal);
//                    return await Task.FromResult(user);
//                }

//                return null;
//            }
//            else
//            {
//                return null;
//            }
//        }
//    }
//}

