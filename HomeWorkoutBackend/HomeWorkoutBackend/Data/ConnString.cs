namespace HomeWorkOutApi.NetCore.Data
{
    public static class ConnString
    {
        public static bool TryGetConnectionString(IConfiguration configuration, string dbSection, out string connString)
        {
            connString = null;

            IConfigurationSection serversSection = configuration.GetSection("Servers");
            IConfigurationSection s = serversSection.GetSection(dbSection);

            string host = s.GetValue<string>("Server");
            string db = s.GetValue<string>("Database");
            string usrnm = s.GetValue<string>("User Id");
            string pwdEncrypted = s.GetValue<string>("Password");

            if (string.IsNullOrWhiteSpace(host)
                || string.IsNullOrWhiteSpace(db)
                || string.IsNullOrWhiteSpace(usrnm)
                || string.IsNullOrWhiteSpace(pwdEncrypted))
                return false;

            string pwd = pwdEncrypted; // example -> AES

            connString = $"Server={host};Database={db};UserId={usrnm};Password={pwd}";

            return true;
        }
    }
}
