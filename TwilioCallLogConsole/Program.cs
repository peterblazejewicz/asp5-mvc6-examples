using System;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using Twilio;

namespace TwilioCallLogConsole
{
    public class Program
    {
        public IRuntimeOptions Options { get; set; }
        public IConfiguration Configuration { get; set; }

        public Program(IRuntimeOptions options)
        {
            this.Options = options;
        }
        public void Main(string[] args)
        {
            // Setup configuration sources.
            // The order in which Configuration is built
            // is important
            var builder = new ConfigurationBuilder(Options.ApplicationBaseDirectory)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .AddUserSecrets()
                .AddCommandLine(args);
            Configuration = builder.Build();
            // Instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(
              Configuration.Get("AccountSid"),
              Configuration.Get("AuthToken")
            );
            // Select all calls from my account
            var calls = client.ListCalls(new CallListRequest());
            // Check for any exceptions
            if (calls.RestException != null)
            {
                throw new FormatException(calls.RestException.Message);
            }
            // Loop through them and show information
            foreach (var call in calls.Calls)
            {
                var callDetails = $"From: {call.From}, Day: {call.DateCreated}, Duration: {call.Duration}s";
                Console.WriteLine(callDetails);
            }
            Console.WriteLine(Options.ApplicationName);
            Console.ReadLine();
        }
    }
}
