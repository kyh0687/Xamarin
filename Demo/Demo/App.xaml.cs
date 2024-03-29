﻿using Demo.ViewModels;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo
{
    public partial class App : Application
    {
        private static Account account;
        public static Account Account
        {
            get
            {
                if (account != null)
                {
                    return account;
                }
                else if (App.Current.Properties.ContainsKey("account"))
                {
                    return App.Current.Properties["account"] as Account;
                }

                return null;
            }
            set
            {
                account = value;

                // 자동 로그인 시에만 내부 Property 저장
                if (App.Current.Properties.ContainsKey("IsAutoLogin") &&
                   (bool)(App.Current.Properties["IsAutoLogin"]))
                {
                    // Property 저장
                    App.Current.Properties["account"] = value;
                    App.Current.SavePropertiesAsync();
                }
            }
        }

        public static IList<Purchase> PurchaseHistory { get; set; }

        public App()
        {
            InitializeComponent();

            PurchaseHistory = new List<Purchase>();

            MainPage = new NavigationPage(new TabbedMainPage());
        }

        protected override void OnStart()
        {
            base.OnStart();
            
        }

        
    }
}
