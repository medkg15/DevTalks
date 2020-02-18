using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    /// <summary>
    /// Mailer depends on an account to do its work.
    /// </summary>
    public class Mailer
    {
        public string CreateWelcomeMessage(Account account)
        {
            return
                $"Welcome, {account.FirstName} {account.LastName}.  Your MemberID is {account.MemberId}.  You can log in to our website with your UserID {account.UserId} ....";
        }
    }
}
