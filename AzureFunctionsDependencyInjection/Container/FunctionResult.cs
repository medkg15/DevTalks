using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class FunctionResult<T>
    {
        public bool Success { get; set; }
        public bool Retry { get; set; }
        public T Result { get; set; }
    }
}
