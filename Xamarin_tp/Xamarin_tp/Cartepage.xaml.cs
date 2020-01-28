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
            public Cartepage()
            {
          

                Title = "Map view of all the messages";

                Position position = new Position(43.610768333333333, 3.876715);
                MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);

                Map map = new Map(mapSpan);
                
                Pin pin = new Pin
                {
                    Label = "Santa Cruz",
                    Address = "The city with a boardwalk",
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
        protected override void OnAppearing()
        {
            Position position = new Position(43.610768333333333, 3.876715);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);

            Map map = new Map(mapSpan);
            base.OnAppearing();
            var pin = new Pin
            {
                Position = new Position(36.891, 10.181),
                Label = "Position 1",
                Address = "Address 1",
            };

            map.Pins.Add(pin);

        }

    }
}