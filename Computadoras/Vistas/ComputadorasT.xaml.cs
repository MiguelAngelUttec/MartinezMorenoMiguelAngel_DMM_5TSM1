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
    public partial class ComputadorasT : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public ComputadorasT()
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
                db.CreateTable<computadora>();
                IEnumerable<computadora> resultado = SELECT_WHERE(db, txtBModelo.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaComputadora());
                    DisplayAlert("Aviso", "Sí existen computadoras con ese nombre", "ok");
                }
                else
                {
                    DisplayAlert("Aviso", "No existen modelos con ese nombre", "ok");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
            public static IEnumerable<computadora> SELECT_WHERE(SQLiteConnection db, string modelo)
            {
                return db.Query<computadora>("SELECT * FROM computadora WHERE modelo=?", modelo);
            }

            private void BtnRegistrar_Clicked(object sender, EventArgs e)
            {
                Navigation.PushAsync(new Vistas.RegistroComputadora());
            }

        
    }
}