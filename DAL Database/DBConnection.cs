using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.Configuration.Json;


namespace DAL_Database
{
    public class DBConnection
    {
        public string GetConnectionString()
        {
            //Install 2 Libraries are Microsoft.Extensions.Configuration and Microsoft.Configuration.Json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnecting").Value;
        }
    }
}
