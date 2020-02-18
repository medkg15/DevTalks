using System;
using System.Collections.Generic;
using System.Text;

namespace Examples
{
    public class AddressParser
    {
        public Address Parse(string input)
        {
            // do some stuff with "input" here ...
            // maybe a regex, maybe some other technique ...

            return new Address
            {
                StreetNumber = "123",
                StreetName = "Main",
                StreetType = "Street",
                Town = "Hartford",
                State = "CT",
                ZipCode = "06101",
            };
        }
    }
}
