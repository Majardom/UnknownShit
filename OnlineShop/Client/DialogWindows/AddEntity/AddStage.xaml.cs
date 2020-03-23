using BLL.DTO;
using BLL.Interfaces.Services;
using Client.WebServices;
using Newtonsoft.Json;
using System.IO;
using System.Messaging;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;

namespace Client.DialogWindows.AddEntity
{
    /// <summary>
    /// Interaction logic for AddStage.xaml
    /// </summary>
    public partial class AddStage : Window
    {
        private IOrdersService _orderService;

        public AddStage(IOrdersService orderService)
        {
            InitializeComponent();

            _orderService = orderService;
        }

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            var stage = new StageDto() { Caption = StageCaption_Tb.Text };

            var request = WebRequest.Create("http://localhost/online_shop_wcf_services/StageService.svc/stages");
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json";

            var serializer = new JsonSerializer();

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            using (var writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, stage);
            }

            var response = request.GetResponse();

            Close();
        }

        private void MSMQButton_Click(object sender, RoutedEventArgs e)
        {
            var stage = new StageDto() { Caption = StageCaption_Tb.Text };

            var client = OnlineShopWebServicesContainer.Instance.StagesMSMQClientInstance;
            
            client.AddStage(stage);

            Close();
        }
    }
}
