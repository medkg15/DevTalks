using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class State : IState
    {
        public string Name { get; }

        public State(string name)
        {
            Name = name;
        }
    }
}
