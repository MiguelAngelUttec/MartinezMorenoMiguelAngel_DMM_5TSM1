using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using Computadoras.iOS;
using Xamarin.Forms;
using System.IO;
using Computadoras.Base;

[assembly: Dependency(typeof(SQLiteDB))]
namespace Computadoras.iOS
{
    public class SQLiteDB : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(ruta, "Computadoras.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}