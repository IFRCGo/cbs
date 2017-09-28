using System;
using System.Collections.Generic;
using doLittle.DependencyInversion;

namespace Infrastructure.AspNet
{
    public class Container : IContainer
    {
        readonly IServiceProvider _serviceProvider;

        public Container(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public void Bind(Type service, Func<Type> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<Type> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, Func<Type> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<Type> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<T> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, Func<Type, object> resolveCallback)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Func<T> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, Func<Type, object> resolveCallback, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Type type)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, Type type)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(Type type, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, Type type, BindingLifecycle lifecycle)
        {
            throw new NotImplementedException();
        }

        public void Bind<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public void Bind(Type service, object instance)
        {
            throw new NotImplementedException();
        }

        public T Get<T>()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(bool optional)
        {
            throw new NotImplementedException();
        }

        public object Get(Type type)
        {
            return _serviceProvider.GetService(type);
        }

        public object Get(Type type, bool optional)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAll(Type type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Type> GetBoundServices()
        {
            throw new NotImplementedException();
        }

        public bool HasBindingFor(Type type)
        {
            throw new NotImplementedException();
        }

        public bool HasBindingFor<T>()
        {
            throw new NotImplementedException();
        }
    }
}