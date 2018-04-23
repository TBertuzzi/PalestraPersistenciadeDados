using LiteDB;
using LiteDBXamarinExemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LiteDBXamarinExemplo.Helpers;

namespace LiteDBXamarinExemplo
{
	public partial class MainPage : ContentPage
	{
        LiteDatabase _dataBase;
		public MainPage()
		{
			InitializeComponent();

            _dataBase = new LiteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MeuBanco.db"));
		}

        private void btnGerarPorco_Clicked(object sender, EventArgs e)
        {
           

            LiteCollection<Porco> Porcos = _dataBase.GetCollection<Porco>();

            int idPorco = Porcos.Count() + 1;
            Porco porco = new Porco
            {
                id = idPorco,
                Nome = "Rodolfo",
                Idade = 3,
                Apelidos = new string[] { "Rodie", "Rodolfinho" },
                VirouBacon = false
            };

            Porcos.Upsert(porco);

            lbStatusPorco.Text = "Porco Criado!";
    }
        private void btnTransformaBacon_Clicked(object sender, EventArgs e)
        {

            LiteCollection<Porco> Porcos = _dataBase.GetCollection<Porco>();

            if (Porcos.Count() > 0)
            {
                var porco = Porcos.FindAll().FirstOrDefault();
                porco.VirouBacon = true;
                Porcos.Upsert(porco);

                lbStatusPorco.Text = "Virou Bacon";
            }

        }

        private void btnRetornaPorco_Clicked(object sender, EventArgs e)
        {

            LiteCollection<Porco> Porcos = _dataBase.GetCollection<Porco>();

            if (Porcos.Count() > 0)
            {
                var porco = Porcos.FindAll().FirstOrDefault();
                lbStatusPorco.Text =  porco.VirouBacon ? "Bacon" : porco.Nome;
            }

        }


    }
}
