using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stablo.Repository
{
    public class DIModule : Autofac.Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be registered.</param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(DIModule).Assembly)
                   .Where(t => t.Name.EndsWith("Repository") && !t.Name.Equals("FileRepository")).AsImplementedInterfaces();
        }
    }
}
