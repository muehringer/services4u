using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Base.Domain;

namespace Base.Application
{
    public class ApplicationToDomainMapping : Profile
    {
        public ApplicationToDomainMapping()
        {
            CreateMap<SampleVm, Sample>();

            #region Exemplos de implementações

            //Mapper.CreateMap<Sala, Unidade>().ForMember(u => u.Nome, map => map.MapFrom(s => s.Nome));//Ou utiliza esse ou o de baixo
            //Mapper.CreateMap<Sala, Unidade>().ForMember(u => u.isAtivo, map => map.Ignore()); //Ou utiliza esse ou o de cima
            //Mapper.CreateMap<Person, Employee>().ForMember(emp => emp.Fullname, map => map.MapFrom(p => p.Firstname + " " + p.Lastname));
            //Mapper.CreateMap<Employee, EmployeeStats>().ForMember(d => d.SickDaysUsed, o => o.Ignore());

            #endregion
        }
    }
}
