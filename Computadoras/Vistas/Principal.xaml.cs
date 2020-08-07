using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Computadoras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
            btn_Computadora.Clicked += Btn_Computadora_Clicked;
            btn_Gerente.Clicked += Btn_Gerente_Clicked;
            btn_Sucursal.Clicked += Btn_Sucursal_Clicked;
        }

        private void Btn_Sucursal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sucursal());
        }

        private void Btn_Gerente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Gerente());
        }

        private void Btn_Computadora_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ComputadorasT());
        }
    }
}