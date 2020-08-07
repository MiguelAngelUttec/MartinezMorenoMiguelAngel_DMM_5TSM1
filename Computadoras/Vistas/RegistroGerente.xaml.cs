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
    public partial class RegistroGerente : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public RegistroGerente()
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            btnGuardar.Clicked += BtnGuardar_Clicked;
        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            var datosGerente = new gerentes
            {
                nombres = txtNombres.Text,
                apellido_Pat = txtApellidoP.Text,
                apellido_Mat = txtApellidoM.Text,
                curp = txtCurp.Text,
                rfc = txtNRfc.Text
            };
            conexion.InsertAsync(datosGerente);
            limpiarFormulario();
            DisplayAlert("Éxito", "El gerente se registró correctamente", "OK");
        }
        void limpiarFormulario()
        {
            txtNombres.Text = "";
            txtApellidoP.Text = "";
            txtApellidoM.Text = "";
            txtCurp.Text = "";
            txtNRfc.Text = "";


        }
    }
}