using Android.Support.V4.Content;
using Demo.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    { 
        public SettingPage()
        { 
            InitializeComponent();

            LoginSwitch.IsToggled = (App.Account != null) ? true : false;

            LoginSwitch.Toggled             += LoginSwitch_Toggled;
            CookieButton.Clicked            += CookieButton_Clicked;
            PhotoImage_Camera.Clicked       += CameraButtonClicked;
            PhotoImage_Gallery.Clicked      += GalleryButtonClicked;

            // DependencyService!! 
            // Xamarin.Form에서 Native Platform 기능 가져다 쓰기. 런타임에 작동
            // Gallery Image Get Test
            IDirectoryService directoryService = DependencyService.Get<IDirectoryService>();

            var picDir = directoryService.GetExternalPictureDir();
            var galleryPath = Path.Combine(picDir, "Sample/test_1.jpg");
            PhotoImage_Gallery.Source = ImageSource.FromFile(galleryPath);

            // Url Image Get Test
            PhotoImage_URI.Source = new UriImageSource() { Uri = new Uri("https://aka.ms/campus.jpg") };
        }

        /// <summary>
        /// 카메라 
        /// </summary>
        async void CameraButtonClicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                Directory = "Sample",
                Name = "test.jpg",
                SaveToAlbum = true
            });

            Console.WriteLine(photo.AlbumPath);

            await DisplayAlert("AlbumPath", photo.AlbumPath, "OK");

            if (photo != null)
                PhotoImage_Camera.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        /// <summary>
        /// 갤러리 
        /// </summary>
        async void GalleryButtonClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
            {
                PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 100
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            PhotoImage_Gallery.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        /// <summary>
        /// 로그인 스위치
        /// </summary>
        async void LoginSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            Console.WriteLine(e.Value);

            var lsLogin = e.Value;

            if (lsLogin)
            {
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("로그아웃", "로그아웃 되었습니다.", "OK");
                App.Account = null;
                BindingContext = null;
            }
        }

        /// <summary>
        /// 쿠키
        /// </summary>
        async void CookieButton_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            await DisplayAlert("쿠키삭제", "Local Data가 모두 초기화되었습니다.", "OK");
        }
    }
}