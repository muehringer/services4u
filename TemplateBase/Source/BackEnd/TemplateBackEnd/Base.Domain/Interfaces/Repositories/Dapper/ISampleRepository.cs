using Base.Domain.Entities;
using Base.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Domain.Interfaces.Repositories.Dapper
{
    public interface ISampleRepository
    {
        ResultData<Sample> GetById(int id);
        ResultData<Sample> GetAll();
        ResultData<Sample> Insert(Sample entity);
        ResultData<Sample> Update(Sample entity);
        ResultData<Sample> Delete(int id);
    }
}
