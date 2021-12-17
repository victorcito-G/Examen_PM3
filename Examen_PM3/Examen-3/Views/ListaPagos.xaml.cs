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
    public partial class ListaPagos : ContentPage
    {
        public ListaPagos()
        {
            InitializeComponent();
        }

        private async void ListaPrecios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Pagos item = (Models.Pagos)e.Item;
          /// await DisplayAlert("Elemento Tocado " , "Descripcion: " + item.Descripcion, "Ok");

            var page = new VistaAgregar();
           page.BindingContext = item;
           await Navigation.PushModalAsync(page);
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPagos());
        }
    }
    

}