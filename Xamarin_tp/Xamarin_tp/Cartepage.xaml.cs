using Newtonsoft.Json;
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
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Cartepage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("Xamarin_tp.Places.json");
                string text = string.Empty;
                using (var reader = new StreamReader(stream))
                {
                    text = reader.ReadToEnd();
                }

                var resultObject = JsonConvert.DeserializeObject<Places>(text);

                foreach (var place in resultObject.results)
                {
                    placesList.Add(new Place
                    {
                        PlaceName = place.name,
                        Address = place.vicinity,
                        Location = place.geometry.location,
                        Position = new Position(place.geometry.location.lat, place.geometry.location.lng),
                        //Icon = place.icon,
                        //Distance = $"{GetDistance(lat1, lon1, place.geometry.location.lat, place.geometry.location.lng, DistanceUnit.Kiliometers).ToString("N2")}km",
                        //OpenNow = GetOpenHours(place?.opening_hours?.open_now)
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