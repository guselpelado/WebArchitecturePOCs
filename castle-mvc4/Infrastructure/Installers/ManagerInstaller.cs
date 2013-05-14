using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace castle_mvc4.Infrastructure.Installers
{
    public class ManagerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(type => type.Name.EndsWith("Manager"))
                .WithServiceDefaultInterfaces()
                .Configure(c => c.LifestyleTransient()));
        }
    }
}