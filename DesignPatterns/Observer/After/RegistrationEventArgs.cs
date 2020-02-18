using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class RegistrationEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int Id { get; set; }
    }
}
