using LiteDB;
using LiteDBImagensExemplo.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LiteDBImagensExemplo
{
	public partial class MainPage : ContentPage
	{
        LiteDatabase _dataBase;
        string identificador = "idImagem";
        public MainPage()
		{
			InitializeComponent();

            _dataBase = new LiteDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("MeuBanco.db"));

            if (_dataBase.FileStorage.Exists(identificador))
            {
                Stream stream = _dataBase.FileStorage.OpenRead(identificador);
                imgExibir.Source = ImageSource.FromStream(() => stream);
            }
        }


        private void btnSalvar_Clicked(object sender, EventArgs e)
        {

            //Url para gravar a imagem
            Stream stream = GetImageStreamFromUrl("https://github.com/TBertuzzi/LiteDBImagensExemplo/blob/master/Resources/kirby.jpg?raw=true");

            //Se existir a Stream
            if (stream != null)
            {
                //Verfica se ja existe a imagem,se existir apaga
                if (_dataBase.FileStorage.Exists(identificador))
                {
                    _dataBase.FileStorage.Delete(identificador);
                }
                _dataBase.FileStorage.Upload(identificador, "Teste", stream);

            }

        }

        //Método para transformar a imagem da URL em Stream
        private  Stream GetImageStreamFromUrl(string url)
        {
            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    Stream stream = new MemoryStream(imageBytes);
                    return stream;
                }
            }
            return null;
        }
    }
}
