using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Examples.Test
{
    public class LetterPrinterTests
    {
        private readonly Letter Letter = new Letter
        {
            RecipientName = "John Smith",
            ToAddress = "123 Main Street Hartford CT, 06101",
            Body = "Greeting John, ...",
        };

        [Fact]
        public void FirstLine_IsRecipient()
        {
            // arrange
            using (var writer = new StringWriter())
            {
                var systemUnderTest = new LetterPrinter(writer);

                // act
                systemUnderTest.Print(Letter);

                // assert
                var lines = writer.ToString().Split("\r\n");
                Assert.Equal("John Smith", lines[0]);
            }
        }

        [Fact]
        public void SecondLine_IsStreet()
        {
            using (var writer = new StringWriter())
            {
                var systemUnderTest = new LetterPrinter(writer);

                systemUnderTest.Print(Letter);

                var lines = writer.ToString().Split("\r\n");
                Assert.Equal("123 Main Street", lines[1]);
            }
        }

        [Fact]
        public void ThirdLine_IsTownStateZip()
        {
            using (var writer = new StringWriter())
            {
                var systemUnderTest = new LetterPrinter(writer);

                systemUnderTest.Print(Letter);

                var lines = writer.ToString().Split("\r\n");
                Assert.Equal("Hartford CT, 06101", lines[2]);
            }
        }
    }
}
