using System;
using System.Collections.Generic;
using System.Text;
using Base.Infrastructure;

namespace Base.Domain
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
