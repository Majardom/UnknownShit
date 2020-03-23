using BLL.DTO;
using System;

namespace Client.WebServices
{
    public interface IMSMQService 
    {
        void AddStage(StageDto stage);
    }

    public class OnlineShopWebServicesContainer
    {
        private static readonly Lazy<OnlineShopWebServicesContainer> lazy =
              new Lazy<OnlineShopWebServicesContainer>(() => new OnlineShopWebServicesContainer());


        public static OnlineShopWebServicesContainer Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public localhost.OrdersService OrderService { get; }

        
        public StagesMSMQRef.StagesMSMQClient StagesMSMQClientInstance { get => new StagesMSMQRef.StagesMSMQClient(); }

        private OnlineShopWebServicesContainer()
        {
            OrderService = new localhost.OrdersService();
        }
    }
}
