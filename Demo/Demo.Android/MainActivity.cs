using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Plugin.CurrentActivity;
using System.IO;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;

namespace Demo.Droid
{
    [Activity(Label = "@string/ApplicationName", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Syncfusion Trial Version 인증키.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ0Nzg3QDMxMzcyZTMyMmUzMGw2WnZpd2pqVDA1L2d5WW1zaWJ4LytQaTFRbjY2aVRRTW5PcHFFNFFTOWM9");

            LoadApplication(new App());

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += Push_PushNotificationReceived;
                AppCenter.Start("1ecadb09-33a9-4a94-b417-84161bd51760", typeof(Push));
            }
        }

        private void Push_PushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        {
            var summary = $"Push notification received:" +
                            $"\n\tNotification title: {e.Title}" +
                            $"\n\tMessage: {e.Message}";

            // If there is custom data associated with the notification,
            // print the entries
            if (e.CustomData != null)
            {
                summary += "\n\tCustom data:\n";
                foreach (var key in e.CustomData.Keys)
                {
                    summary += $"\t\t{key} : {e.CustomData[key]}\n";
                }
            }

            // Send the notification summary to debug output
            System.Diagnostics.Debug.WriteLine(summary);
        }
    }

}