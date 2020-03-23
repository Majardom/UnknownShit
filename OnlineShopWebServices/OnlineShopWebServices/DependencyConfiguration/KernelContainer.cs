using BLL.DependencyConfiguration;
using Ninject;

namespace OnlineShopWebServices.DependencyConfiguration
{
    public class KernelContainer
    {
        private static KernelContainer _instance;

        public static KernelContainer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KernelContainer();

                return _instance;
            }
        }

        public IKernel Kernel { get; }

        private KernelContainer()
        {
            Kernel = new StandardKernel(
              new DalModule("OnlineShopDb"),
              new BllModule()
           );
        }

    }
}