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
    public partial class DetalleSucursal : ContentPage
    {
        public int IdSeleccionado;
        public string NomSeleccionado, DirSeleccionado, CPSeleccionado, IdGeSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<sucursal> ResultadoDelete;
        IEnumerable<sucursal> ResultadoUpdate;
        public DetalleSucursal(int id, string nombre, string dir, string cp, string idG)
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            IdSeleccionado = id;
            NomSeleccionado = nombre;
            DirSeleccionado = dir;
            CPSeleccionado = cp;
            IdGeSeleccionado = idG;
            btn_actualizar.Clicked += Btn_actualizar_Clicked;
            btn_eliminar.Clicked += Btn_eliminar_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensaje.Text = " ID :" + IdSeleccionado;
            txtNombre.Text = NomSeleccionado;
            txtDireccion.Text = DirSeleccionado;
            txtCodigoPostal.Text = CPSeleccionado;
            txtIdGerente.Text = IdGeSeleccionado;
        }
        private void Btn_eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Computadoras.db3");
            var db = new SQLiteConnection(rutaBD);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Éxito", "La sucursal se eliminó correctamente", "OK");
            Limpiar();
        }
        private void Btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Computadoras.db3");
            var db = new SQLiteConnection(rutaBD);
            ResultadoUpdate = Update(db, txtNombre.Text, txtDireccion.Text, txtCodigoPostal.Text,
            txtIdGerente.Text, IdSeleccionado);
            DisplayAlert("Éxito", "La sucursal se actualizó correctamente", "OK");
        }
        public static IEnumerable<sucursal> Delete(SQLiteConnection db, int id)
        {
            return db.Query<sucursal>("DELETE FROM sucursal where id_sucursal = ?", id);
        }
        public static IEnumerable<sucursal> Update(SQLiteConnection db, string nombre, string
        direccion, string codigoPostal, string id_gerente, int id)
        {
            return db.Query<sucursal>("UPDATE sucursal SET nombre = ?, direccion = ?, codigoPostal = ?, id_gerente = ? where id_sucursal = ? ",
                nombre, direccion, codigoPostal, id_gerente, id);
        }
        public void Limpiar()
        {
            lblMensaje.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtCodigoPostal.Text = "";
            txtIdGerente.Text = "";
        }
    }
}