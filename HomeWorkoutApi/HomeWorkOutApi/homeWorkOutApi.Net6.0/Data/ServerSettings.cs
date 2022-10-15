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
        public string Host { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get; private set; }

        #endregion

        #region .Ctor

        public ServerSettings(string name, string host, string database, string username, string password)
        {
            Name = name;
            Host = host;
            Database = database;
            Username = username;
            Password = password;
            ConnectionString = $"Host={host};Database={database};Username={username};Password={password}";
        }

        #endregion
    }
}
