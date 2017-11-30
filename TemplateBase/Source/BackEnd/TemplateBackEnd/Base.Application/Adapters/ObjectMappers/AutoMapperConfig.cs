using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Adapters.ObjectMappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(p => {
                p.AddProfile<DomainToApplicationMapping>();
                p.AddProfile<ApplicationToDomainMapping>();
            });
        }
    }
}
