using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public interface IMemberIdRegistry
    {
        int AssignId(string firstName, string lastName);
    }
}
