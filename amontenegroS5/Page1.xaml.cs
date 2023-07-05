using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace amontenegroS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        private const string URL = "http://192.168.17.19/moviles/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<amontenegroS5.Datos> post;

        public Page1()
        {
            InitializeComponent();
            obtener();
        }
        private async void obtener()
        {
            var contenido = await cliente.GetStringAsync(URL);
            List<amontenegroS5.Datos> listaPost = JsonConvert.DeserializeObject<List<amontenegroS5.Datos>>(contenido);
            post = new ObservableCollection<Datos>(listaPost);
            listaEstudiantes.ItemsSource = post;
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Datos)e.SelectedItem;
            /*int codigo = Convert.ToInt32(objetoEstudiante.codigo.ToString());
            string nombre = objetoEstudiante.codigo.ToString();
            string apellido = objetoEstudiante.codigo.ToString();
            int edad = Convert.ToInt32(objetoEstudiante.codigo.ToString());*/
            Navigation.PushAsync(new Actualizar(objetoEstudiante));
        }
    }
}