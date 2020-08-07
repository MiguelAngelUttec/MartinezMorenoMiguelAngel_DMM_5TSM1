using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Computadoras.Tablas;
using System.Collections.ObjectModel;
using System.IO;
using Computadoras.Base;

namespace Computadoras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaSucursal : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<sucursal> TablaSucursales;
        public ConsultaSucursal()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            ListaSucursales.ItemSelected += ListaSucursales_ItemSelected;
        }
        private void ListaSucursales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (sucursal)e.SelectedItem;
            var item = Obj.id_sucursal.ToString();
            var nombre = Obj.nombre;
            var dir = Obj.direccion;
            var cp = Obj.codigoPostal;
            var idGe = Obj.id_gerente;
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new DetalleSucursal(ID, nombre, dir, cp, idGe));
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected async override void OnAppearing()
        {
            var ResulRegistros = await conexion.Table<sucursal>().ToListAsync();
            TablaSucursales = new ObservableCollection<sucursal>(ResulRegistros);
            ListaSucursales.ItemsSource = TablaSucursales;
            base.OnAppearing();
        }
    }
}