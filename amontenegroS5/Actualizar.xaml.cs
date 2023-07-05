using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace amontenegroS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        public Actualizar(Datos datos)
        {
            InitializeComponent();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre.ToString();
            txtApellido.Text = datos.apellido.ToString();
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string URL = "http://192.168.17.19/moviles/post.php";

                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string edad = txtEdad.Text;


                string URLParametros = $"{URL}?codigo={codigo}&nombre={nombre}&apellido={apellido}&edad={edad}";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues(URLParametros, "PUT", parametros);
                DisplayAlert("Alerta", "Actualizacion correcta", "cerrar");
                Navigation.PushAsync(new Page1()); ;

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "cerrar");

            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string URL = "http://192.168.17.19/moviles/post.php";

                string codigo = txtCodigo.Text;
                string URLParametros = $"{URL}?codigo={codigo}";

                var parametros = new System.Collections.Specialized.NameValueCollection();
                cliente.UploadValues(URLParametros, "DELETE", parametros);
                DisplayAlert("Alerta", "Eliminación correcta", "cerrar");
                Navigation.PushAsync(new Page1()); ;

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "cerrar");

            }
        }
    }
}