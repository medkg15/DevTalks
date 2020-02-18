using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Examples.Test
{
    public class AddressParserTests
    {
        [Fact]
        public void SimpleAddress_IsParsed()
        {
            // arrange
            var systemUnderTest = new AddressParser();

            // act
            var result = systemUnderTest.Parse("123 Main Street Hartford CT 06101");

            // assert
            Assert.Equal("123", result.StreetNumber);
            Assert.Equal("Main", result.StreetName);
            Assert.Equal("Street", result.StreetType);
            Assert.Equal("Hartford", result.Town);
            Assert.Equal("CT", result.State);
            Assert.Equal("06101", result.ZipCode);
        }

        [Fact]
        public void MissingStreetNumber_IsParsed()
        {
            var systemUnderTest = new AddressParser();

            var result = systemUnderTest.Parse("Main Street Hartford CT 06101");

            Assert.Null(result.StreetNumber);
            Assert.Equal("Main", result.StreetName);
            Assert.Equal("Street", result.StreetType);
            Assert.Equal("Hartford", result.Town);
            Assert.Equal("CT", result.State);
            Assert.Equal("06101", result.ZipCode);
        }
    }
}
