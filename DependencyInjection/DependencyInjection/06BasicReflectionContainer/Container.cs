using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjection._7BasicReflectionContainer
{
    public class Container
    {
        public T Get<T>()
        {
            var description = new TypeDescription(typeof(T));

            return (T)Create(description);
        }

        private object Create(TypeDescription description)
        {
            if (!description.Dependencies.Any())
            {
                return Activator.CreateInstance(description.Type);
            }

            object[] dependencies = description.Dependencies.Select(Create).ToArray();

            return Activator.CreateInstance(description.Type, dependencies);
        }

        private class TypeDescription
        {
            private ConstructorDescription _constructor;

            public TypeDescription(Type type)
            {
                Type = type;

                var constructor = type
                    .GetConstructors()
                    .SingleOrDefault(); // we're only going to support classes with a single public ctor right now ...

                if (constructor != null)
                {
                    _constructor = new ConstructorDescription(constructor);
                }
            }

            public Type Type { get; }

            public IEnumerable<TypeDescription> Dependencies
            {
                get { return _constructor.ParameterTypes.Select(p => new TypeDescription(p)); }
            }
        }

        private class ConstructorDescription
        {
            private readonly ConstructorInfo _info;

            public ConstructorDescription(ConstructorInfo info)
            {
                _info = info;
            }

            public IEnumerable<Type> ParameterTypes
            {
                get { return _info.GetParameters().Select(p => p.ParameterType); }
            }
        }
    }
}
