using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.AddressParserRefactor
{
    public interface IAddressParser
    {
        Address Parse(string input);
    }
}
