using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Examples.AddressParserRefactor
{
    public class LetterPrinter
    {
        private readonly IAddressParser parser;
        private readonly TextWriter writer;

        public LetterPrinter(IAddressParser parser, TextWriter writer)
        {
            this.parser = parser;
            this.writer = writer;
        }

        public void Print(Letter letter)
        {
            // parse the address so we can work with its components individually
            var address = parser.Parse(letter.ToAddress);

            // write the recipient info + address on the top of the letter
            writer.WriteLine(letter.RecipientName);

            writer.WriteLine($"{address.StreetNumber} {address.StreetName} {address.StreetType}");
            writer.WriteLine($"{address.Town} {address.State}, {address.ZipCode}");

            // write the letter body copy
            writer.WriteLine(letter.Body);
        }
    }
}
