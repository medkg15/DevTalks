using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Container
{
    /// <summary>
    /// The Azure function.
    /// </summary>
    public class MyFunction
    {
        /// <summary>
        /// Standard Azure function entry point.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> Run(string arg1, string arg2)
        {
            using (var kernel = new StandardKernel())
            {
                var container = kernel.Get<FunctionContainer<MyFunction, Task<HttpResponseMessage>>>();
                var result = container.Run(f => f.RunInternal(arg1, arg2));
                if (result.Success)
                {
                    return await result.Result;
                }

                if (result.Retry)
                {
                    // ?? push back onto the queue.  depending on the mechanics for doing this, maybe the container can?
                    throw new NotImplementedException();
                }

                // not sure how to flag this to azure either
                throw new NotImplementedException();
            }
        }

        private readonly MyService _service;

        public MyFunction(MyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Actual logic for the function.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> RunInternal(string arg1, string arg2)
        {
            _service.DoStuff(arg1);

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
