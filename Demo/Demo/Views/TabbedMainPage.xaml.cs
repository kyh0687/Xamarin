using Demo.ViewModels;
using Demo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMainPage : TabbedPage
    {
        public GoodsPage GoodsPage { get; set; }

        public SettingPage SettingPage { get; set; }

        public ControlTestPage ControlTestPage { get; set; }

        public TabbedMainPage()
        {
            InitializeComponent();

            GoodsPage = new GoodsPage() { Title = "상품리스트", IconImageSource= "ic_action_list_alt.png" };
            SettingPage = new SettingPage() { Title = "설정", IconImageSource = "ic_action_settings.png" };
            ControlTestPage = new ControlTestPage() {Title = "SfTest" };

            // Tab Item은 5개가 MAX임
            Children.Add(GoodsPage);
            //Children.Add(GoodsPageSf);
            Children.Add(SettingPage);
            Children.Add(ControlTestPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            // TODO : 로그인 후 데이터 바인딩 하는 방법 생각해보기!
            // SettingPage의 OnAppearing()에서는 refresh가 안된다.
            SettingPage.BindingContext = App.Account as Account;
        }
    }
}