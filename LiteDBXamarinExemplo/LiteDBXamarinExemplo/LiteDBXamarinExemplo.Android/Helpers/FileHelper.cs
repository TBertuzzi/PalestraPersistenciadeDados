using System;
using System.IO;
using LiteDBXamarinExemplo.Droid.Helpers;
using LiteDBXamarinExemplo.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace LiteDBXamarinExemplo.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
