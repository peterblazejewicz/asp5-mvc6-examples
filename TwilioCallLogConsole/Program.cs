using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;

namespace TwilioCallLogConsole
{
    public class Program
    {
        private readonly string basePath;
        public IApplicationEnvironment ApplicationEnvironment { get; set; }
        public Program(IApplicationEnvironment app,
               IRuntimeEnvironment runtime,
               IRuntimeOptions options)
        {
            ApplicationEnvironment = app;
        }
        public void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder(ApplicationEnvironment.ApplicationBasePath)
                .AddJsonFile("config.json", true)
                .Build().GetConfigurationSection("Twilio");
            Console.WriteLine(configuration.Get("AccountSid"));
            Console.WriteLine(configuration.Get("AuthToken"));
            Console.WriteLine(configuration.Get("MyOwnNumber"));
            Console.WriteLine(configuration.Get("MyTwilioNumber"));
            Console.ReadLine();
        }
    }
}
