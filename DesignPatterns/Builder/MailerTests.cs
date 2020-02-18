using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Builder
{
    /// <summary>
    /// Testing mailer therefore requires us to provide Account instances.
    /// For testing different aspects of the Mailer, we may only care about some aspects of Account - the others can remain the default.
    /// </summary>
    public class MailerTests
    {
        [Fact]
        public void GreetsByName()
        {
            var systemUnderTest = new Mailer();

            var account = new TestAccountBuilder()
                .Build();

            var result = systemUnderTest.CreateWelcomeMessage(account);

            Assert.True(result.Contains("John"));
            Assert.True(result.Contains("Smith"));
        }

        [Fact]
        public void IncludesDisclaimerForSpecialPlan()
        {
            var systemUnderTest = new Mailer();

            var account = new TestAccountBuilder()
                .WithPlan("X12345")
                .Build();

            var result = systemUnderTest.CreateWelcomeMessage(account);

            Assert.True(result.Contains("Your plan requires a consent form which you can download at ..."));
        }
    }
}
