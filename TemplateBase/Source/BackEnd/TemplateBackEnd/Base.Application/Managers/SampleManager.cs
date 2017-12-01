using AutoMapper;
using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.Domain.Entities;
using Base.Domain.Interfaces.Repositories;
using Base.Domain.Interfaces.UnitOfWork;
using Base.Infrastructure.Enums;
using Base.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Managers
{
    public class SampleManager : ISampleManager
    {
        private ISampleRepository sampleRepository;

        public SampleManager(ISampleRepository _sampleRepository)
        {
            this.sampleRepository = _sampleRepository;
        }

        public ResultData<SampleVm> GetAll()
        {
            //uso de transacao
            //using (var scope = new TransactionScope()) {

            ResultData<SampleVm> resultData = new ResultData<SampleVm>();
            ResultData<Sample> resultSample = new ResultData<Sample>();

            resultSample = this.sampleRepository.GetAll();

            //Uso Auto Mapper
            resultData = Mapper.Map<ResultData<Sample>, ResultData<SampleVm>>(resultSample);

            if (resultData.ExceptionCode.Equals(1)) {
                //scope.Dispose();

                return new ResultData<SampleVm> { ExceptionCode = Convert.ToInt32(ExceptionType.Error), ExceptionMessage = "Não foi possível exibir o exemplo." };
            }

            //scope.Complete();
            return resultData;
            //}

            //return new ResultData<SampleVm> { ExceptionCode = Convert.ToInt32(ExceptionType.Ok), ExceptionMessage = "Exemplo salvo com sucesso." };

        }
    }
}
