using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWorkOutApi.NetCore.Data
{
    public class ServerSettings
    {
        #region Properties

        public string Name { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; private set; }

        #endregion

        #region .Ctor

        public ServerSettings(string name, string server, string database, string userId, string password)
        {
            Name = name;
            Server = server;
            Database = database;
            UserId = userId;
            Password = password;
            ConnectionString = $"Server={server};Database={database};User Id={userId};Password={password};TrustServerCertificate=True";
        }

        #endregion
    }
}
