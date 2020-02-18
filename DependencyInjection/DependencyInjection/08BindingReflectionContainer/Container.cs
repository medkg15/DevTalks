using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjection._8BindingReflectionContainer
{
    public class Container
    {
        public T Get<T>()
        {
            var description = new TypeDescription(typeof(T));

            return (T)Create(description);
        }

        public object Create(TypeDescription description)
        {
            // if we have a binding from the given type, substitute the binding implementation type.
            if (_bindings.ContainsKey(description.Type))
            {
                description = new TypeDescription(_bindings[description.Type]);
            }

            if (!description.Dependencies.Any())
            {
                return Activator.CreateInstance(description.Type);
            }

            object[] dependencies = description.Dependencies.Select(Create).ToArray();

            return Activator.CreateInstance(description.Type, dependencies);
        }

        public class TypeDescription
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

        public class ConstructorDescription
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

        private IDictionary<Type, Type> _bindings = new Dictionary<Type, Type>();

        public void Bind<T, TImplementation>() where TImplementation : T
        {
            _bindings.Add(typeof(T), typeof(TImplementation));
        }
    }
}
