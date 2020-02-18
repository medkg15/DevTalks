using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Examples
{
    public class LetterPrinter
    {
        private readonly TextWriter writer;

        public LetterPrinter(TextWriter writer)
        {
            this.writer = writer;
        }

        public void Print(Letter letter)
        {
            var parser = new AddressParser();

            // parse the address so we can work with its components individually
            var address = parser.Parse(letter.ToAddress);

            // write the recipient info + address on the top of the letter
            writer.WriteLine(letter.RecipientName);

            writer.WriteLine($"{address.StreetNumber} {address.StreetName} {address.StreetType}");
            writer.WriteLine($"{address.Town} {address.State}, {address.ZipCode}");

            writer.WriteLine("-----------");
            // write the letter body copy
            writer.WriteLine(letter.Body);
        }
    }
}
