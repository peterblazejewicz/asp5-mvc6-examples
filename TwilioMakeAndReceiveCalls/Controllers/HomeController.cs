using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Twilio;
using Twilio.TwiML;

namespace TwilioMakeAndReceiveCalls.Controllers
{
    public class HomeController : Controller
    {

        private readonly TwilioSettings _twilioSettings;

        /*
          Twilio settings are injected via dependency injectio
        */
        public HomeController(TwilioSettings twilioSettings)
        {
            _twilioSettings = twilioSettings;
        }

        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public IActionResult MakeCall(string number)
        {
            var client = new TwilioRestClient("", "");
            var results = client.InitiateOutboundCall("Twilio.MyNumber", "number", "http://www.televisiontunes.com/uploads/audio/Star%20Wars%20-%20The%20Imperial%20March.mp3");
            if (results.RestException != null)
            {
                return Content(results.RestException.Message);
            }
            return Content("The call has been is initiated");
        }

        [HttpGet]
        public IActionResult ReceiveCall()
        {
            var twiml = new TwilioResponse();
            twiml.Say("You are calling Marcos Placona").Dial("MyOwnNumber");
            return Content(twiml.ToString());
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
