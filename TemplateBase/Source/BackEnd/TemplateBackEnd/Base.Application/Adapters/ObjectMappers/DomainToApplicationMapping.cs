using AutoMapper;
using Base.Application.ViewModels;
using Base.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Adapters.ObjectMappers
{
    public class DomainToApplicationMapping : Profile
    {
        public DomainToApplicationMapping()
        {
            CreateMap<Sample, SampleVm>();

            #region Exemplos de implementações

            //Mapper.CreateMap<Sala, Unidade>().ForMember(u => u.Nome, map => map.MapFrom(s => s.Nome));//Ou utiliza esse ou o de baixo
            //Mapper.CreateMap<Sala, Unidade>().ForMember(u => u.isAtivo, map => map.Ignore()); //Ou utiliza esse ou o de cima
            //Mapper.CreateMap<Person, Employee>().ForMember(emp => emp.Fullname, map => map.MapFrom(p => p.Firstname + " " + p.Lastname));
            //Mapper.CreateMap<Employee, EmployeeStats>().ForMember(d => d.SickDaysUsed, o => o.Ignore());

            #endregion
        }
    }
}
