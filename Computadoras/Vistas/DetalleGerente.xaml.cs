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
    public partial class DetalleGerente : ContentPage
    {
        public int IdSeleccionado;
        public string NomSeleccionado, ApPSeleccionado, ApMSeleccionado, CurpSeleccionado, RfcSelecconado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<gerentes> ResultadoDelete;
        IEnumerable<gerentes> ResultadoUpdate;
        public DetalleGerente(int id, string nombres, string apP, string apM, string curp, string rfc)
        {
            InitializeComponent();
            conexion = DependencyService.Get<ISQLite>().GetConnection();
            IdSeleccionado = id;
            NomSeleccionado = nombres;
            ApPSeleccionado = apP;
            ApMSeleccionado = apM;
            CurpSeleccionado = curp;
            RfcSelecconado = rfc;
            btn_actualizar.Clicked += Btn_actualizar_Clicked;
            btn_eliminar.Clicked += Btn_eliminar_Clicked;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lblMensaje.Text = " ID :" + IdSeleccionado;
            txtNombres.Text = NomSeleccionado;
            txtApellidoPa.Text = ApPSeleccionado;
            txtApellidoMa.Text = ApMSeleccionado;
            txtCurp.Text = CurpSeleccionado;
            txtRfc.Text = RfcSelecconado;
        }

        private void Btn_eliminar_Clicked(object sender, EventArgs e)
        {
            var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Computadoras.db3");
            var db = new SQLiteConnection(rutaBD);
            ResultadoDelete = Delete(db, IdSeleccionado);
            DisplayAlert("Éxito", "El gerente se eliminó correctamente", "OK");
            Limpiar();
        }

        private void Btn_actualizar_Clicked(object sender, EventArgs e)
        {
            var rutaBD = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Computadoras.db3");
            var db = new SQLiteConnection(rutaBD);
            ResultadoUpdate = Update(db, txtNombres.Text, txtApellidoPa.Text, txtApellidoMa.Text,
            txtCurp.Text, txtRfc.Text, IdSeleccionado);
            DisplayAlert("Éxito", "El gerente se actualizó correctamente", "OK");
        }
        public static IEnumerable<gerentes> Delete(SQLiteConnection db, int id)
        {
            return db.Query<gerentes>("DELETE FROM gerentes where id_gerente = ?", id);
        }
        public static IEnumerable<gerentes> Update(SQLiteConnection db, string nombres, string
        apellidoPa, string apellidoMa, string curp, string rfc, int id)
        {
            return db.Query<gerentes>("UPDATE gerentes SET nombres = ?, apellido_Pat = ?, apellido_Mat = ?, curp = ?, rfc = ? where id_gerente = ? ", 
                nombres, apellidoPa, apellidoMa, curp, rfc, id);
        }
        public void Limpiar()
        {
            lblMensaje.Text = "";
            txtNombres.Text = "";
            txtApellidoPa.Text = "";
            txtApellidoMa.Text = "";
            txtCurp.Text = "";
            txtRfc.Text = "";
        }
    }
}