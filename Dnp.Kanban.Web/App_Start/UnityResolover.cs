using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Dnp.Kanban.Web
{
    public class UnityResolover : IDependencyResolver
    {
        protected IUnityContainer _container;

        public UnityResolover(IUnityContainer container)
        {
            if( container == null)
            {
                throw new ArgumentNullException("Container");
            }

            this._container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolover(child);
        }

        public void Dispose()
        {
            this._container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this._container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
    }
}