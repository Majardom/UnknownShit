using BLL.DTO;
using BLL.Interfaces.Services;
using Ninject;
using OnlineShopWebServices.DependencyConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OnlineShopWebWcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class StageService : IStageService
    {
        private readonly IOrdersService _orderService; 

        public StageService()
        {
            _orderService = KernelContainer.Instance.Kernel.Get<IOrdersService>();
        }

        public IEnumerable<StageDto> GetAllStages()
        {
            return _orderService.GetAllOrderStages();
        }

        public void AddStage(StageDto stage)
        {
            _orderService.AddStage(stage);
        }
    }
}
