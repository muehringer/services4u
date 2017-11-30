using Base.Domain.Entities;
using Base.Domain.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Interfaces.Repositories
{
    public interface ISampleRepository : IUnitOfWork<Sample, int>
    {
    }
}
