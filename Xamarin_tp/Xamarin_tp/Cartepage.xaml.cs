using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Xamarin_tp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cartepage : ContentPage
    {
            public Cartepage()
            {
                Title = "Map view of all the messages";

                Position position = new Position(36.9628066, -122.0194722);
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
    }
}