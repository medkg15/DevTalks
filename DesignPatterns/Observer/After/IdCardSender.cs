using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Observer
{
    public class IdCardSender
    {
        private readonly HttpClient _client;

        public IdCardSender(HttpClient client)
        {
            _client = client;
        }

        public void SendCardForRegistration(object sender, RegistrationEventArgs args)
        {
            var request = new
            {
                name = args.Name,
                id = args.Id,
            };

            _client.PostAsync("https://idcardvendor.com/api/idcard",
                new StringContent(JsonConvert.SerializeObject(request)));
        }
    }
}