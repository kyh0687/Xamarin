using Xamarin.Forms;
using System.Runtime.CompilerServices;

// DependencyService에 플랫폼 구현을 등록해야 Xamarin.Forms가 런터임에 해당 구현을 찾을 수 있음
[assembly: Xamarin.Forms.Dependency(typeof(Demo.Droid.DirectoryService))]
namespace Demo.Droid
{

    /// <summary>
    /// 내부저장소, 외부저장소로 나뉨
    /// 내부저장소 : 각 어플리케이션만 데이터 접근 가능, 어플리케이션 지우면 같이 사라짐
    /// 외부저장소 : 외부 어플리케이션에서도 데이터 접근 가능
    /// </summary>
    public class DirectoryService : IDirectoryService
    {
        /// <summary>
        /// 내부 캐시 폴더 (Essentials 에서 제공)
        /// </summary>
        /// <returns>/data/user/0/com.Demo/cache</returns>
        public string GetCacheDir()
        {
            return Xamarin.Essentials.FileSystem.CacheDirectory;
        }

        /// <summary>
        /// 내부 폴더 경로  
        /// </summary>
        /// <returns>/data/user/0/com.Demo/files/Pictures</returns>
        public string GetInternalPictureDir()
        { 
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
        }

        /// <summary>
        /// 외부 이미지 폴더 경로
        /// 권한 필요 : READ_EXTERNAL_STORAGE, WRITE_EXTERNAL_STORAGE
        /// </summary>
        /// <returns>/storage/emulated/0/Pictures</returns>
        public string GetExternalPictureDir()
        {
            // /storage/emulated/0
            //var temp1 = Android.OS.Environment.ExternalStorageDirectory.Path;

            // /storage/emulated/0/DCIM
            //var temp2 = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).Path;

            // /storage/emulated/0/Pictures
            //var temp3 = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).Path;

            return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).Path;
        }

        
    }
}