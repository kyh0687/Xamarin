using Demo.ViewModels;
using Syncfusion.SfChart.XForms;
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
    public partial class SfChartPage : ContentPage
    {
        public SfChartPage()
        {
            InitializeComponent();

            ColumnSeries series = new ColumnSeries()
            {
                ItemsSource = App.PurchaseHistory,
                XBindingPath = "Id",
                YBindingPath = "TotalCount",
            };
            PurchaseChart.Series.Add(series);

        }
    }
}