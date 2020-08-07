using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Computadoras.Droid;
//using Computadoras.Base;
using Xamarin.Forms;

[assembly: Dependency(typeof(ISQLite))]
namespace Computadoras.Droid
{
    public class ISQLite : Computadoras.Base.ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(ruta, "Computadoras.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}