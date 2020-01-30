﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin_tp.Models;
using System.IO;
using System.Diagnostics;
using SQLite;

namespace Xamarin_tp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cartepage : ContentPage
    {

        public Cartepage()
        {
            InitializeComponent();

            Title = "Map view of all the messages";
            Task.Delay(2000);
            UpdateMap();
            
        }
        List<Place> placesList = new List<Place>();

        private async void UpdateMap()
        {
            try
            {
               

         
                string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);
                var table = db.Table<Message>();
                foreach (var s in table)
                {
                    Console.WriteLine(s.id + " Oui oui ça marche! " + s.student_message);

                
                        placesList.Add(new Place
                        {
                            PlaceName =s.student_id.ToString(),
                            Address = s.student_message,
                      
                            Position = new Position(s.gps_lat, s.gps_long),
                  
                        });
                    
                }

                MyMap.ItemsSource = placesList;
                //PlacesListView.ItemsSource = placesList;
                //var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(43.632291, 3.862669818), Distance.FromKilometers(100)));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }
       
    }
}