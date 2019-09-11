using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public interface IDirectoryService
    {
        string GetCacheDir();

        string GetInternalPictureDir();
        string GetExternalPictureDir();
    }
}
