using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class ExceptionVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Whether to retry.</returns>
        public bool Visit(Exception exception)
        {
            return false;
        }
    }
}
