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

namespace Computadoras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroComputadora : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public RegistroComputadora()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            btnGuardar.Clicked += BtnGuardar_Clicked;
        }
        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var datosComputadora = new computadora
            {
                marca = txtMarca.Text,
                modelo = txtModelo.Text,
                procesador = txtProcesador.Text,
                ram = txtRam.Text,
                rom = txtRom.Text,
                id_sucursal = txtSucursal.Text
                
            };
            conexion.InsertAsync(datosComputadora);
            limpiarFormulario();
            DisplayAlert("Éxito", "La computadora se registró correctamente", "OK");
        }
        void limpiarFormulario()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtProcesador.Text = "";
            txtRam.Text = "";
            txtRom.Text = "";
            txtSucursal.Text = "";

        }
    }
}