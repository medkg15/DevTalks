using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection._6FuncContainer
{
    public class Container
    {
        private Dictionary<Type, Func<object>> _bindings = new Dictionary<Type, Func<object>>();

        public void Register<T>(Func<T> func)
        {
            // convert from Func<T> to Func<object> so a single dictionary can store multiple type resolvers
            Func<object> resolver = () => func();

            _bindings.Add(typeof(T), resolver);
        }

        public T Get<T>()
        {
            if (_bindings.ContainsKey(typeof(T)))
            {
                return default(T); // or choose to throw an exception.  e.g. Ninject throws an exception if the type isn't self-bindable.
            }

            Func<object> resolver = _bindings[typeof(T)];
            var result = resolver();
            return (T)result;
        }
    }
}
