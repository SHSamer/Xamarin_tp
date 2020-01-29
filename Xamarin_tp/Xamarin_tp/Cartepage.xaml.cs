using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin_tp.Models;

namespace Xamarin_tp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cartepage : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        private const string Url = "https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/";
        private ObservableCollection<Account> account;
        public Cartepage()
        {
            InitializeComponent();

            Title = "Map view of all the messages";
        }

                
        async override protected void OnAppearing()
        {
            string responsecontent = await _client.GetStringAsync(Url);
            List<Account> mylist = JsonConvert.DeserializeObject<List<Account>>(responsecontent);
            account = new ObservableCollection<Account>(mylist);
            MyMap.ItemsSource = account;
            base.OnAppearing();
            Position position = new Position(43.610768333333333, 3.876715);
                MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);

                Map map = new Map(mapSpan);
            
                Pin pin = new Pin
                {
                    Label = "wiw", 
                    Address = "Hello i'm still strugling",
                    Type = PinType.Place,
                    Position = position
                };
                map.Pins.Add(pin);

            Content = new StackLayout
             {
                 Margin = new Thickness(10),
                 Children =
                 {
                 map
                 }
             };
       }
    }

}