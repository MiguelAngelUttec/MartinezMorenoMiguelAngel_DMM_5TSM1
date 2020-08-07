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
    public partial class ConsultaComputadora : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<computadora> TablaComputadoras;
        public ConsultaComputadora()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            ListaComputadoras.ItemSelected += ListaGerentes_ItemSelected;
        }
        private void ListaGerentes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (computadora)e.SelectedItem;
            var item = Obj.id_computadora.ToString();
            var marca = Obj.marca;
            var modelo = Obj.modelo;
            var procesador = Obj.procesador;
            var ram = Obj.ram;
            var rom = Obj.rom;
            var id_sucursal = Obj.id_sucursal;
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new DetalleComputadora(ID, marca, modelo, procesador, ram, rom, id_sucursal));
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected async override void OnAppearing()
        {
            var ResulRegistros = await conexion.Table<computadora>().ToListAsync();
            TablaComputadoras = new ObservableCollection<computadora>(ResulRegistros);
            ListaComputadoras.ItemsSource = TablaComputadoras;
            base.OnAppearing();
        }

    }
}