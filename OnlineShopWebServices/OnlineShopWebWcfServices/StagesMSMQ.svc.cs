using BLL.DTO;
using BLL.Interfaces.Services;
using Ninject;
using OnlineShopWebServices.DependencyConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnlineShopWebWcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StagesMSMQ" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StagesMSMQ.svc or StagesMSMQ.svc.cs at the Solution Explorer and start debugging.
    public class StagesMSMQ : IStagesMSMQ
    {
        private readonly IOrdersService _orderService;

        public StagesMSMQ()
        {
            _orderService = KernelContainer.Instance.Kernel.Get<IOrdersService>();
        }

        public void AddStage(StageDto stage)
        {
            _orderService.AddStage(stage);
        }
    }
}
