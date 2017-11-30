using Base.Application.Interfaces;
using Base.Application.Managers;
using Base.Application.ViewModels;
using Base.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Base.Services.Controllers
{
    public class TesteController : ApiController
    {
        private readonly ISampleManager app;

        public TesteController(ISampleManager sampleManager)
        {
            app = sampleManager;
        }

        //[Authorize]
        public ResultData<SampleVm> Get()
        {
            return app.GetAll();
        }
    }
}
