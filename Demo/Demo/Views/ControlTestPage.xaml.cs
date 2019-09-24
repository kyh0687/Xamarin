using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlTestPage : ContentPage
    {
        public ControlTestPage()
        {
            InitializeComponent();
        }

        async void SfButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SfButtonPage());
        }

        async void SfChartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SfChartPage());
        }
        
        async void SfListViewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SfListViewPage());
        }
        
    }
}