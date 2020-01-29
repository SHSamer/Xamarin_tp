using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_tp.Models;

namespace Xamarin_tp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage

    {
      
        private readonly HttpClient _client = new HttpClient();
        private const string Url = "https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/";
        private ObservableCollection<Account> account;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"myDB.db3");

            
        public Page1()
        {
            Title = "Home"; 
            InitializeComponent();
        }
        private async void Button_clicked_Listview(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void Button_clicked_Mapview(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new Cartepage());

        }

       
    }
}