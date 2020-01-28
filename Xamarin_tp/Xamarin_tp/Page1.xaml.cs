using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_tp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
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