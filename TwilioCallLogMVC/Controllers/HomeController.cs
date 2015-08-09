using System;
using Microsoft.AspNet.Mvc;
using TwilioCallLogMVC.Models;
using Microsoft.Framework.OptionsModel;
using Twilio;

namespace TwilioCallLogMVC.Controllers
{
    public class HomeController : Controller
    {

        [FromServices]
        public IOptions<TwilioSettings> Settings { get; set; }

        public IActionResult Index(string phoneNumber)
        {
            // Instantiate a new Twilio Rest Client
            var client = new TwilioRestClient(
              Settings.Options.AccountSid,
              Settings.Options.AuthToken
            );
            // Select all calls from my account based on a phoneNumber
            var calls = client.ListCalls(new CallListRequest()
            {
                To = phoneNumber
            });
            // Check for any exceptions
            if (calls.RestException != null)
            {
                throw new FormatException(calls.RestException.Message);
            }
            return View(calls.Calls);
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
