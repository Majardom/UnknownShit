using BLL.DTO;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace OnlineShopWebWcfServices
{
    [ServiceContract]
    public interface IStageService
    {
        [OperationContract]
        [WebGet(UriTemplate = "stages", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IEnumerable<StageDto> GetAllStages();

        [OperationContract]
        [WebInvoke(Method ="POST", UriTemplate = "stages", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void AddStage(StageDto stage);
    }
}
