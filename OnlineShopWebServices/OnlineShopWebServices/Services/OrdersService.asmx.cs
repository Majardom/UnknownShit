using BLL.DTO;
using BLL.Interfaces.Services;
using Ninject;
using OnlineShopWebServices.DependencyConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace OnlineShopWebServices.Services
{
    /// <summary>
    /// Summary description for OrdersService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrdersService : System.Web.Services.WebService
    {
        private readonly IProductsService _productService; 

        public OrdersService()
        {
            _productService = KernelContainer.Instance.Kernel.Get<IProductsService>();
        }

        [WebMethod]
        public List<ProductDto> GetAllProducts()
        {
            return _productService.GetAllProducts().ToList();
        }
    }
}
