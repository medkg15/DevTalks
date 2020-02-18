using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using Newtonsoft.Json;

namespace Observer
{
    public class RegistrationSystem_Before
    {
        private readonly HttpClient _httpClient;
        private readonly SmtpClient _smtpClient;
        private readonly IDbConnection _connection;
        private readonly string _fromAddress;
        private readonly string _subject;
        private readonly IMemberIdRegistry _idRegistry;

        public RegistrationSystem_Before(HttpClient httpClient, SmtpClient smtpClient, 
            IDbConnection connection, string fromAddress, string subject, 
            IMemberIdRegistry idRegistry)
        {
            _httpClient = httpClient;
            _smtpClient = smtpClient;
            _connection = connection;
            _fromAddress = fromAddress;
            _subject = subject;
            _idRegistry = idRegistry;
        }
        public void Register(string firstName, string lastName, string emailAddress)
        {
            // perform the "core" registration logic: 
            // generate an ID
            // track the registration in our db
            var id = _idRegistry.AssignId(firstName, lastName);

            var cmd = _connection.CreateCommand();
            cmd.CommandText = "insert into ....";
            cmd.ExecuteNonQuery();
            
            // then, call our ID card vendor to notify them of the new member, so that they can send the ID card.
            var request = new
            {
                name = $"{firstName} {lastName}",
                id = id
            };

            _httpClient.PostAsync("https://idcardvendor.com/api/idcard",
                new StringContent(JsonConvert.SerializeObject(request)));

            // send an email welcoming the new member...
            _smtpClient.Send(new MailMessage(_fromAddress, emailAddress, _subject, "Welcome, ...."));
        }
    }
}
