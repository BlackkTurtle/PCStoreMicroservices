using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.APIData.Contracts
{
    public interface IModelAPIService
    {
        Task<double> GetModelPrediction(string comment);
    }
}
