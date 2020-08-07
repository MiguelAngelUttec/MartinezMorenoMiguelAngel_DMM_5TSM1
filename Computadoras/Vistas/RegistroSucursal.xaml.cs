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
    public partial class RegistroSucursal : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public RegistroSucursal()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            btnGuardar.Clicked += BtnGuardar_Clicked;
        }
        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var datosSucursal = new sucursal
            {
                nombre = txtNombre.Text,
                direccion = txtDireccion.Text,
                codigoPostal = txtCodigoPostal.Text,
                id_gerente = txtIdGerente.Text
            };
            conexion.InsertAsync(datosSucursal);
            limpiarFormulario();
            DisplayAlert("Éxito", "La sucursal se registró correctamente", "OK");
        }
        void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCodigoPostal.Text = "";
            txtIdGerente.Text = "";

        }
    }
}