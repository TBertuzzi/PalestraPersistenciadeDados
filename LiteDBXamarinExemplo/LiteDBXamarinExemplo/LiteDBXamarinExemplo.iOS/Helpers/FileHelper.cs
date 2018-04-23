using System;
using System.IO;
using LiteDBXamarinExemplo.Helpers;
using LiteDBXamarinExemplo.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace LiteDBXamarinExemplo.iOS.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
