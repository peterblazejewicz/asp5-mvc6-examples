using System;

namespace TwilioMakeAndReceiveCalls
{
    public class TwilioSettings
    {
        // TWILIO_ACCOUNT_SID
        public string AccountSid { get; set; }
        // TWILIO_AUTH_TOKEN
        public string AuthToken { get; set; }
        // MY_NUMBER
        public string MyOwnNumber { get; set; }
        // TWILIO_NUMBER
        public string MyTwilioNumber { get; set; }
    }
}
