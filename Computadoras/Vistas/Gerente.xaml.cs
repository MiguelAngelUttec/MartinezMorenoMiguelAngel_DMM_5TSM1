using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Computadoras.Base;
using Computadoras.Tablas;
using System.IO;

namespace Computadoras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gerente : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Gerente()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
            btnBuscar.Clicked += BtnBuscar_Clicked;
        }

        private void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var rutaDB = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Computadoras.db3");
                var db = new SQLiteConnection(rutaDB);
                db.CreateTable <gerentes>();
                IEnumerable<gerentes> resultado = SELECT_WHERE(db, txtBNombre.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaGerente());
                    DisplayAlert("Aviso", "Sí existen gerentes con ese nombre", "ok");
                }
                else
                {
                    DisplayAlert("Aviso", "No existen gerentes con ese nombre", "ok");
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public static IEnumerable<gerentes> SELECT_WHERE(SQLiteConnection db, string nombre)
        {
            return db.Query<gerentes>("SELECT * FROM gerentes WHERE nombres=?", nombre);
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Vistas.RegistroGerente());
        }
    }
}