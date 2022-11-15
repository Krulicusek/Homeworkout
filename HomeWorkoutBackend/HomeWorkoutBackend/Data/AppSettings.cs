using HomeWorkOutApi.NetCore.Data;
using NLog;

namespace homeWorkOutApi.Net6.Data
{
    public class AppSettings
    {
        #region Members

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        IConfiguration Configuration;
        public List<string> TestUsers;
        public string TestUsersPassword;
        public List<string> AllowedUsers;
        public string SecurityLogin;

        #endregion

        #region Properties

        public bool IsTest { get; private set; }
        public ServerSettings ServerSettings { get; private set; }

        #endregion

        #region .Ctor

        public AppSettings(IConfiguration configuration)
        {
            try
            {
                Configuration = configuration;
                IsTest = configuration.GetValue<bool>("IsTest");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        #endregion

        #region Methods

        public void GetServerSettings()
        {
            try
            {
                IConfigurationSection serversSection = Configuration.GetSection("Servers");
                string serverMode = IsTest ? "HomeWorkoutTest" : "HomeWorkout";
                IConfigurationSection serverDataSection = serversSection.GetSection(serverMode);
                string server = serverDataSection.GetValue<string>("Server");
                string db = serverDataSection.GetValue<string>("Database");
                string userId = serverDataSection.GetValue<string>("User Id");
                string pwdEncrypted = serverDataSection.GetValue<string>("Password");

                if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(db) || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(pwdEncrypted))
                {
                    throw new Exception("Server data invalid");
                }

                string pwd = pwdEncrypted; //decrypt
                ServerSettings = new ServerSettings(serverMode, server, db, userId, pwd);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return;
            }
        }

        public void GetTestUsers()
        {
            try
            {
                if (!IsTest)
                {
                    string[] users = Configuration.GetSection("TestUsersData:TestUsers").Get<string[]>();
                    string password = Configuration.GetSection("TestUsersData:Password").Get<string>();

                    if (users == null || users.Length == 0 || string.IsNullOrEmpty(password))
                    {
                        throw new Exception("TestUsers data invalid");
                    }

                    TestUsers = users.ToList();
                    TestUsersPassword = password;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return;
            }
        }

        public void GetAllowedUsers()
        {
            try
            {
                if (!IsTest)
                {
                    string[] users = Configuration.GetSection("Allowed").Get<string[]>();
                    string securityLogin = Configuration.GetSection("SecurityLogin").Get<string>();

                    if (users == null || users.Length == 0 || string.IsNullOrEmpty(securityLogin))
                    {
                        throw new Exception("AllowedUsers data invalid");
                    }

                    AllowedUsers = users.ToList();
                    SecurityLogin = securityLogin;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return;
            }
        }

   
        #endregion
    }
}
