using AutoMapper;
using BLL.DTO;
using BLL.Interfaces.Services;
using Client.DialogWindows.AddEntity;
using Client.WebServices;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductsService _productService;
        private readonly IProductsService _productSerializationService;
        private readonly IOrdersService _ordersService;

        public MainWindow(IProductsService productService, IProductsService productSerializationService, IOrdersService ordersService)
        {
            InitializeComponent();

            _productService = productService
                ?? throw new ArgumentNullException(nameof(productService));

            _productSerializationService = productSerializationService
                ?? throw new ArgumentNullException(nameof(productSerializationService));

            _ordersService = ordersService
                ?? throw new ArgumentNullException(nameof(ordersService));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = App.Container.Get<AddStage>();

            dialog.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var products = OnlineShopWebServicesContainer.Instance.OrderService.GetAllProducts().Select(x => Mapper.Map<ProductDto>(x)).ToList();
            Product_Grid.ItemsSource = products;

            LoadStagesGrid();
        }

        private void Json_Btn_Click(object sender, RoutedEventArgs e)
        {
            var products = _productService.GetAllProducts().ToList();

            _productSerializationService.SaveToJson(products);
        }

        private void Xml_Btn_Click(object sender, RoutedEventArgs e)
        {
            var products = _productService.GetAllProducts().ToList();

            _productSerializationService.SaveToXml(products);
        }

        private void DataContact_Btn_Click(object sender, RoutedEventArgs e)
        {
            var products = OnlineShopWebServicesContainer.Instance.OrderService.GetAllProducts().Select(x => Mapper.Map<ProductDto>(x)).ToList();

            _productSerializationService.SaveToDataContract(products);
        }

        private void LoadStagesGrid()
        {
            var request = WebRequest.Create("http://localhost/online_shop_wcf_services/StageService.svc/stages");
            request.Credentials = CredentialCache.DefaultCredentials;

            var response = request.GetResponse();

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                var json = sr.ReadToEnd();
                var stages = JsonConvert.DeserializeObject<List<StageDto>>(json);
                Stages_Grid.ItemsSource = stages;
            }
        }

        private void Refresh_Btn_Click(object sender, RoutedEventArgs e)
        {
            LoadStagesGrid();
        }
    }
}
