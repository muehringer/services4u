using System;
using System.Collections.Generic;
using System.Text;
using Base.Infrastructure;
using Base.Domain;
using System.Transactions;
using AutoMapper;

namespace Base.Application
{
    public class SampleManager : ISampleManager
    {
         private ISampleRepository sampleRepository;
         private readonly IMapper mapper;

        public SampleManager(ISampleRepository _sampleRepository, IMapper _mapper)
        {
            this.sampleRepository = _sampleRepository;
            this.mapper = _mapper;
        }

        public ResultData<SampleVm> GetAll()
        {
            //uso de transacao
            //using (var scope = new TransactionScope()) {
           var resultSample = this.sampleRepository.GetAll();
            //Uso Auto Mapper
            var resultData = mapper.Map<ResultData<Sample>, ResultData<SampleVm>>(resultSample);

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
