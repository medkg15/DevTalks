using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class FunctionContainer<TFunction, TResult>
    {
        private readonly TFunction _function;
        private readonly ExceptionVisitor _visitor;

        public FunctionContainer(TFunction function, ExceptionVisitor visitor)
        {
            _function = function;
            _visitor = visitor;
        }

        public FunctionResult<TResult> Run(Func<TFunction, TResult> method)
        {
            try
            {
                var result = method(_function);

                return new FunctionResult<TResult>
                {
                    Success = true,
                    Result = result,
                };
            }
            catch (Exception e)
            {
                var retry = _visitor.Visit(e);

                return new FunctionResult<TResult>
                {
                    Success = false,
                    Retry = retry,
                };
            }
        }
    }
}
