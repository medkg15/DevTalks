﻿using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    public class Transition : ITransition
    {
        public Transition(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
