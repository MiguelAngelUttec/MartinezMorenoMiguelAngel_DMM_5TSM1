using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Computadoras.Tablas;
using Computadoras.Base;
using SQLite;
using System.IO;

namespace Computadoras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleComputadora : ContentPage
    {
        public int IdSeleccionado;
        public string MarcaSeleccionado, ModeloSeleccionado, ProcesadorSeleccionado, RamSeleccionado, RomSelecconado, IdSucursalSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<computadora> ResultadoDelete;
        IEnumerable<computadora> ResultadoUpdate;
        public DetalleComputadora(int id, string marca, string modelo, string procesador, string ram, string rom, string id_sucursal)
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            IdSeleccionado = id;
            MarcaSeleccionado = marca;
            ModeloSeleccionado = modelo;
            ProcesadorSeleccionado = procesador;
            RamSeleccionado = ram;
            RomSelecconado = rom;
            IdSucursalSeleccionado = id_sucursal;
            btn_actualizar.Clicked += Btn_actualizar_Clicked;
            btn_eliminar.Clicked += Btn_eliminar_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensaje.Text = " ID :" + IdSeleccionado;
            txtMarca.Text = MarcaSeleccionado;
            txtModelo.Text = ModeloSeleccionado;
            txtProcesador.Text = ProcesadorSeleccionado;
            txtRam.Text = RamSeleccionado;
            txtRom.Text = RomSelecconado;
            txtId_Sucursal.Text = IdSucursalSeleccionado;
        }
        private void Btn_eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Computadoras.db3");
            var db = new SQLiteConnection(rutaBD);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Éxito", "La computadora se eliminó correctamente", "OK");
            Limpiar();
        }
        private void Btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Computadoras.db3");
            var db = new SQLiteConnection(rutaBD);
            ResultadoUpdate = Update(db, txtMarca.Text, txtModelo.Text, txtProcesador.Text,
            txtRam.Text, txtRom.Text, txtId_Sucursal.Text, IdSeleccionado);
            DisplayAlert("Éxito", "La computadora se actualizó correctamente", "OK");
        }
        public static IEnumerable<computadora> Delete(SQLiteConnection db, int id)
        {
            return db.Query<computadora>("DELETE FROM computadora where id_computadora = ?", id);
        }
        public static IEnumerable<computadora> Update(SQLiteConnection db, string marca, string
        modelo, string procesador, string ram, string rom, string idSucursal, int id)
        {
            return db.Query<computadora>("UPDATE computadora SET marca = ?, modelo = ?, procesador = ?, ram = ?, rom = ?, id_sucursal = ? where id_computadora = ? ",
                marca, modelo, procesador, ram, rom, idSucursal, id);
        }
        public void Limpiar()
        {
            lblMensaje.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtProcesador.Text = "";
            txtRam.Text = "";
            txtRom.Text = "";
            txtId_Sucursal.Text = "";
        }
    }
}