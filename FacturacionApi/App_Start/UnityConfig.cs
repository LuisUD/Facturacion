using DataAccess;
using Servicios;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using FacturacionApi.Controllers;

namespace FacturacionApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();


            //container.RegisterType<FacturacionContext>();
            container.RegisterType<ClientesService>();
            container.RegisterType<ProductosService>();
            container.RegisterType<VentasService>();
            container.RegisterType<FacturasService>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }

    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
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
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }
    }


}