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
        private ObservableCollection<Message> message;


        public Page1()
        {
            Title = "Home"; 
            InitializeComponent();
            Replir_database(); 
        }
        private async void Button_clicked_Listview(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        private async void Button_clicked_Mapview(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new Cartepage());

        }
        private async void Replir_database()
        {
            string responsecontent = await _client.GetStringAsync(Url);
            List<Message> mylist = JsonConvert.DeserializeObject<List<Message>>(responsecontent);
            message = new ObservableCollection<Message>(mylist);
            
      
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Message>();
            //Repmlir la base de donnee 
            foreach (Message mes in message)
            {
                db.Insert(mes);
            }
            Device.StartTimer(TimeSpan.FromSeconds(30.99), () =>
            {
                Replir_database(); 

                return true;
            });
            Console.WriteLine("Reading data");
            var table = db.Table<Message>();
            foreach (var s in table)
            {
                Console.WriteLine(s.id + " Oui oui ça marche! " + s.student_message);
            }
        }
    }
}