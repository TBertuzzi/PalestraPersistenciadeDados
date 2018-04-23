using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LiteDBImagensExemplo.Droid.Helpers;
using LiteDBImagensExemplo.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace LiteDBImagensExemplo.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}