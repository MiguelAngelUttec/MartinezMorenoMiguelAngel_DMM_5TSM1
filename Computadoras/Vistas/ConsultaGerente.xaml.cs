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
    public partial class ConsultaGerente : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<gerentes> TablaGerentes;
        public ConsultaGerente()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            ListaGerentes.ItemSelected += ListaGerentes_ItemSelected;
        }

        private void ListaGerentes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (gerentes)e.SelectedItem;
            var item = Obj.id_gerente.ToString();
            var nombres = Obj.nombres;
            var apP = Obj.apellido_Pat;
            var apM = Obj.apellido_Mat;
            var curp = Obj.curp;
            var rfc = Obj.rfc;
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new DetalleGerente(ID, nombres, apP, apM, curp, rfc));
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected async override void OnAppearing()
        {
            var ResulRegistros = await conexion.Table<gerentes>().ToListAsync();
            TablaGerentes = new ObservableCollection<gerentes>(ResulRegistros);
            ListaGerentes.ItemsSource = TablaGerentes;
            base.OnAppearing();
        }
    }
}