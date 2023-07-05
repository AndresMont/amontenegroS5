using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace amontenegroS5
{
    public partial class MainPage : ContentPage
    {
        private const string URL = "http://10.2.3.251/moviles/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<amontenegroS5.Datos> post;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(URL);
            List<amontenegroS5.Datos> listaPost = JsonConvert.DeserializeObject<List<amontenegroS5.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listaPost);
            listaEstudiantes.ItemsSource = post;
        }
    }
}
