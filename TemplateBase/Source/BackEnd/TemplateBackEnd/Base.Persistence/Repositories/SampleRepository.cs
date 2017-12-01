using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;
using Base.Domain.Interfaces.UnitOfWork;
using Base.Persistence.Context;
using Base.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Persistence.Repositories
{
    public class SampleRepository : UnitOfWork<Sample, int>, IUnitOfWork<Sample, int>, ISampleRepository
    {
    }
}
