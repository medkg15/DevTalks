using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.AddressParser
{
    public class GoogleApiAddressParser : IAddressParser
    {
        static HttpClient client = new HttpClient();

        public Address Parse(string input)
        {
            return client.GetAsync<Address>("https://api.google.com/maps/address=" + HttpUtility.UrlEncode(input))
                .Result;
        }
    }
}
