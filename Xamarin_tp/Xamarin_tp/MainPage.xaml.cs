using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin_tp.Models;

namespace Xamarin_tp
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        private const string Url = "https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/";
        private ObservableCollection<Account> account;
        public MainPage()
        {
            InitializeComponent();
        }
        async override protected void OnAppearing()
        {
            string responsecontent = await _client.GetStringAsync(Url);
            List<Account> mylist = JsonConvert.DeserializeObject<List<Account>>(responsecontent);
            account = new ObservableCollection<Account>(mylist);
            ItemlistView.ItemsSource = account;
            base.OnAppearing(); 
        }
        private async void Button_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cartepage());
        }
    }
}
