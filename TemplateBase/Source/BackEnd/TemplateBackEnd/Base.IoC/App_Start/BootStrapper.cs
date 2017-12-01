using Base.Application.Interfaces;
using Base.Application.Managers;
using Base.Domain.Interfaces.Repositories;
using Base.Domain.Interfaces.UnitOfWork;
using Base.Persistence.Mapping;
using Base.Persistence.Mapping.Interfaces;
using Base.Persistence.Repositories;
using Base.Persistence.UnitOfWork;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Base.IoC.App_Start.BootStrapper), "Initialize")]
namespace Base.IoC.App_Start
{
    public static class BootStrapper
    {

        public static void Register(Container container)
        {
            container.Register<ISampleManager, SampleManager>(Lifestyle.Transient);
            container.Register<ISampleRepository, SampleRepository>(Lifestyle.Transient);
        }

        public static void Initialize()
        {
        }
    }
}
