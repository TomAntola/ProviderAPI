[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.Inbound.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.Inbound.App_Start.NinjectWebCommon), "Stop")]

namespace Web.Inbound.App_Start
{
    using DAL.Repositories;
    using Domain.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Syntax;
    using Ninject.Web.Common;
    using System;
    using System.Diagnostics.Contracts;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using Web.Common.Security;
    using Web.Inbound.Common.MessageHandlers;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            // Repositories.
            kernel.Bind<IVehicleRepository>().To<VehicleRepository>();

            // Services.
            kernel.Bind<IVehicleService>().To<VehicleService>();

            // Factories.
            kernel.Bind<IPrincipalFactory>().To<GenericPrincipalFactory>();

            // Global Configuration.
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            GlobalConfiguration.Configuration.MessageHandlers.Add(kernel.Get<BasicAuthenticationMessageHandler>());
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolutionRoot;

        public NinjectDependencyScope(IResolutionRoot ResolutionRoot)
        {
            Contract.Assert(ResolutionRoot != null);

            this.resolutionRoot = ResolutionRoot;
        }

        public object GetService(Type serviceType)
        {
            if (resolutionRoot == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }

            return resolutionRoot.TryGet(serviceType);
        }

        public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
        {
            if (resolutionRoot == null)
            {
                throw new ObjectDisposedException("this", "This scope has been disposed");
            }

            return resolutionRoot.GetAll(serviceType);
        }

        public void Dispose()
        {
            var disposable = resolutionRoot as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }

            resolutionRoot = null;
        }
    }

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel Kernel)
            : base(Kernel)
        {
            this.kernel = Kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}
