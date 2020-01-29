using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        Page currPage;
        private readonly HttpClient _client = new HttpClient();
        private const string Url = "https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/";
        private ObservableCollection<Account> account;
        public MainPage()
        {
            Title = "List view of all the messages";
            InitializeComponent();
           



        }


        async override protected void OnAppearing()
        {
            
            string responsecontent = await _client.GetStringAsync(Url);
            List<Account> mylist = JsonConvert.DeserializeObject<List<Account>>(responsecontent);
            account = new ObservableCollection<Account>(mylist);
            ItemlistView.ItemsSource = account;
            base.OnAppearing();
            if (Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
            {
                Device.StartTimer(TimeSpan.FromSeconds(30.99), () =>
                {
                    ItemlistView.BeginRefresh();


                    OnAppearing();

                    ItemlistView.EndRefresh(); 
                   
                    return true;
                });
            }


        }
        private async void Button_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cartepage());
        }
        private async void Button_clicked_refresh(object sender, EventArgs e)
        {
            ItemlistView.BeginRefresh();

            await Navigation.PushAsync(new MainPage());

            ItemlistView.EndRefresh();


        }
        private async void Button_clicked_Home(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());


        }
        
        



    }
}
