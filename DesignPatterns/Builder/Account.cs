using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// Account is an immutable object with a fairly lengthy list of properties.
    /// </summary>
    public class Account
    {
        public Account(string firstName, string lastName, string userId, string memberId, string email, string planId)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.UserId = userId;
            this.MemberId = memberId;
            this.Email = email;
            this.PlanId = planId;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string UserId { get; }
        public string MemberId { get; }
        public string Email { get; }
        public string PlanId { get; }
    }
}
