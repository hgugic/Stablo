using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stablo.WebApi
{
    /// <summary>
    /// DI Module.
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class DIModule : Autofac.Module
    {
        #region Methods

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<ApplicationContext>().As<IApplicationContext>().InstancePerLifetimeScope();
        }

        #endregion Methods
    }
}
