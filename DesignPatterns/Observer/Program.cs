using System;
using System.Net.Http;
using System.Net.Mail;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the publisher
            var registrationSystem = new RegistrationSystem(new SqlConnection(), new MemberIdRegistry());

            // create observers 
            var idCardSender = new IdCardSender(new HttpClient());
            var welcomeMessageSender = new WelcomeMessageSender(new SmtpClient(), ...);

            // bind observers to publisher
            registrationSystem.OnRegistration += idCardSender.SendCardForRegistration;
            registrationSystem.OnRegistration += welcomeMessageSender.SendRegistrationMessage;
        }
    }
}
