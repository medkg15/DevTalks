using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Observer
{
    public class WelcomeMessageSender
    {
        private readonly SmtpClient _smtpClient;
        private string _fromAddress;
        private string _subject;

        public WelcomeMessageSender(SmtpClient smtpClient, string fromAddress, string subject)
        {
            _smtpClient = smtpClient;
            _fromAddress = fromAddress;
            _subject = subject;
        }

        public void SendRegistrationMessage(object sender, RegistrationEventArgs args)
        {
            var message = new MailMessage(_fromAddress, args.EmailAddress, _subject, "Welcome, ....");
            _smtpClient.Send(message);
        }
    }
}
