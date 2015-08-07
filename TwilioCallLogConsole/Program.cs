using System;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using Twilio;

namespace TwilioCallLogConsole
{
    public class Program
    {
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
            // Instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(
              configuration.Get("AccountSid"),
              configuration.Get("AuthToken")
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
            Console.ReadLine();
        }
    }
}
