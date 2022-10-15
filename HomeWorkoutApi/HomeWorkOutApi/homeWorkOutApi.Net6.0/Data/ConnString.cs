namespace HomeWorkOutApi.NetCore.Data
{
    public static class ConnString
    {
        public static bool TryGetConnectionString(IConfiguration configuration, string dbSection, out string connString)
        {
            connString = null;

            IConfigurationSection serversSection = configuration.GetSection("Servers");
            IConfigurationSection s = serversSection.GetSection(dbSection);

            string host = s.GetValue<string>("Host");
            string db = s.GetValue<string>("Database");
            string usrnm = s.GetValue<string>("Username");
            string pwdEncrypted = s.GetValue<string>("Password");

            if (string.IsNullOrWhiteSpace(host)
                || string.IsNullOrWhiteSpace(db)
                || string.IsNullOrWhiteSpace(usrnm)
                || string.IsNullOrWhiteSpace(pwdEncrypted))
                return false;

            string pwd = pwdEncrypted; // example -> AES

            connString = $"Host={host};Database={db};Username={usrnm};Password={pwd}";

            return true;
        }
    }
}
