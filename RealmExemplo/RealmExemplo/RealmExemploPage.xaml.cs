using RealmExemplo.Model;
using Realms;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace RealmExemplo
{
    public partial class RealmExemploPage : ContentPage
    {
        Realm _realm;
        public RealmExemploPage()
        {
            InitializeComponent();
            _realm = Realm.GetInstance();
        }

        void btnAdicionar_Clicked(object sender, System.EventArgs e)
        {
            SistemaOperacional iOS;



            //Transação que implementa IDispose , Necessario Commit
            using (var transaction = _realm.BeginWrite())
            {
                iOS = new SistemaOperacional
                {
                    Nome = "iOS",
                    Versao = 11.3,
                    Id = 1
                };

                _realm.Add(iOS);

                transaction.Commit();
            }

            SistemaOperacional Android;

            //Transação implícita será comitada por padrão
            _realm.Write(() =>
            { 
                Android = new SistemaOperacional
                {
                    Nome = "Android",
                    Versao = 8.1,
                    Id = 2
                };

                _realm.Add(Android);
            });


            SistemaOperacional WindowsPhone = new SistemaOperacional
            {
                Nome = "WindowsPhone",
                Versao = 10,
                Id = 3
            };

            _realm.Write(() =>
            {
                WindowsPhone = _realm.Add(WindowsPhone);
            });

            ExibeSistemasOperacionais();
           
        }

        void btnRemover_Clicked(object sender, System.EventArgs e)
        {

           
            SistemaOperacional SO; 

            using (var transaction = _realm.BeginWrite())
            {
               
                SO = _realm.All<SistemaOperacional>().
                           Where(X => X.Id == 1).FirstOrDefault();
                
                _realm.Remove(SO);

                SO = _realm.All<SistemaOperacional>().
                           Where(X => X.Id == 2).FirstOrDefault();

                _realm.Remove(SO);

                transaction.Commit();
            }


            ExibeSistemasOperacionais();
           

        }

        public void ExibeSistemasOperacionais()
        {
            //Obter
            List<SistemaOperacional> sistemasOperacionais =
                _realm.All<SistemaOperacional>().ToList();

            string sistemas = "";
            foreach (var so in sistemasOperacionais)
            {
                sistemas = sistemas + "," + so.Nome;

            }

            lblSistemas.Text = sistemas.Substring(1);

        }
    }
}
