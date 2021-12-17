using Examen_3.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaAgregar : ContentPage
    {
        public VistaAgregar()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No se soporta el cargar fotos", "ok");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "mifoto.jpg"
            });

            if (file == null)
            {

                return;
            }
            //await DisplayAlert("El path es:", file.Path, "ok");
            image1.Source = file.Path;

            //Console.WriteLine(file.Path);
            Application.Current.Properties["imagen"] = file.Path;
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaPagos());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var _pagos = new Models.Pagos
            {

                Id_pago = Convert.ToInt32(this.idpago.Text),
                Descripcion = this.description.Text,
                Monto = Convert.ToDouble(this.monto.Text),
                Fecha = this.DueDate.Date,


               



                

            };

            if (await App.BaseDatos.deleteAsync(_pagos) != 0)
                await DisplayAlert("Eliminar Persona", "Persona Eliminada Correctamente", "Ok");

                

            else
                await DisplayAlert("Eliminar Persona", "Error al Eliminar Persona!!", "Ok");
            //await DisplayAlert // Convert.ToDateTime( this.DueDate.no),


        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idpago.Text))
            {
                Pagos person = new Pagos()
                {
                    Id_pago = Convert.ToInt32(idpago.Text),
                    Descripcion = description.Text,
                    Monto = Convert.ToInt32(monto.Text)

                };

                //Update Person  
                await App.BaseDatos.SaveTaskAsync(person);

                idpago.Text = string.Empty;
                description.Text = string.Empty;

                await DisplayAlert("Alert", "Pago Actualizado Correctamente", "OK");
                await Navigation.PushModalAsync(new ListaPagos());

            }
            else
            {
                await DisplayAlert("Alert", "Error", "OK");
            }
        }
    }
}