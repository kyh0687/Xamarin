using Demo.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public Dictionary<string, Account> AccountList = new Dictionary<string, Account>();

        public bool _isAutoLogin;
        public bool IsAutoLogin
        {
            get
            {
                if (App.Current.Properties.ContainsKey("IsAutoLogin"))
                {
                    return (bool)App.Current.Properties["IsAutoLogin"];
                }

                return _isAutoLogin;
            }
            set
            {
                _isAutoLogin = value;

                App.Current.Properties["IsAutoLogin"] = value;
            }
        }

        public LoginPage()
        {
            InitializeComponent();

            // TEST 계정 생성
            for (int i = 1; i <= 5; i++)
            {
                var account = new Account()
                {
                    ID = i.ToString(),
                    PW = i.ToString(),
                    Name = $"Test_{i}",
                    Department = $"부서_{i}"
                };
                AccountList.Add(account.ID, account);
            }
            
            // 자동로그인 여부 설정
            switchIsAutoLogin.IsToggled = IsAutoLogin;

            // 자동로그인이면 Property에서 값 가져와서 설정
            if (IsAutoLogin)
            {
                BindingContext = App.Account;
            }

            entryID.TextChanged += Entry_TextChanged;
            entryPW.TextChanged += Entry_TextChanged;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(entryID.Text) &&
                !string.IsNullOrEmpty(entryPW.Text))
            {
                BtnLogin.IsEnabled = true;
            }
            else
            {
                BtnLogin.IsEnabled = false;
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var id = entryID.Text;
            var pw = entryPW.Text;

            if (!AccountList.ContainsKey(id))
            {
                await DisplayAlert("Fail.", "아이디가 존재하지 않습니다.", "확인");
                return;
            }

            var account = AccountList[id];

            if (account.PW != pw)
            {
                await DisplayAlert("Fail.", "비밀번호가 일치하지 않습니다.", "확인");
                return;
            }

            // 자동로그인 여부 저장
            IsAutoLogin = switchIsAutoLogin.IsToggled;

            // 계정정보 저장            
            App.Account = account;

            // TabbedMainPage로 이동
            await Navigation.PopAsync();
        }

    }
}