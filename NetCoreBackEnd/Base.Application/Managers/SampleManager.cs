using System;
using System.Collections.Generic;
using System.Text;
using Base.Infrastructure;
using Base.Domain;
using System.Transactions;

namespace Base.Application
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
            //resultData = Mapper.Map<ResultData<Sample>, ResultData<SampleVm>>(resultSample);

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
