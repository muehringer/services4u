using System;
using System.Collections.Generic;
using System.Text;
using Base.Application;
using Base.Infrastructure;

namespace Base.Application
{
    public interface ISampleManager
    {
        ResultData<SampleVm> GetAll();
    }
}
