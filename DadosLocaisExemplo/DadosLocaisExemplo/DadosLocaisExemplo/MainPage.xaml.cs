using DadosLocaisExemplo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DadosLocaisExemplo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if(Settings.Login.Length > 0)
            {
                txtLogin.Text = Settings.Login;
            }
        }

        private void btnSalvar_Clicked(object sender, EventArgs e)
        {
            Settings.Login = txtLogin.Text;
        }
    }
}
