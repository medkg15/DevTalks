using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// A builder for creating test accounts that provides sensible defaults.  Any aspect can be overriden, as needed for a specific test.
    /// </summary>
    public class TestAccountBuilder
    {
        public TestAccountBuilder()
        {
            _firstName = "John";
            _lastName = "Smith";
            _userId = "jsmith";
            _email = "jsmith@example.com";
            _memberId = "X1234567890";
            _planId = "123X3221";
        }

        private string _firstName;
        private string _lastName;
        private string _userId;
        private string _email;
        private string _memberId;
        private string _planId;

        public TestAccountBuilder WithFirstName(string firstName)
        {
            this._firstName = firstName;

            return this;
        }

        public TestAccountBuilder WithLastName(string lastName)
        {
            this._lastName = lastName;

            return this;
        }

        public TestAccountBuilder WithUserId(string userId)
        {
            this._userId = userId;

            return this;
        }

        public TestAccountBuilder WithMemberId(string memberId)
        {
            this._memberId = memberId;

            return this;
        }

        public TestAccountBuilder WithEmail(string email)
        {
            this._email = email;

            return this;
        }

        public TestAccountBuilder WithPlan(string planId)
        {
            this._planId = planId;

            return this;
        }

        public Account Build()
        {
            return new Account(_firstName, _lastName, _userId, _memberId, _email, _planId);
        }
    }
}
