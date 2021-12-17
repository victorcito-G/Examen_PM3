using Examen_3.ViewModels;
using Examen_3.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_3
{
    public partial class App : Application
    {
        static ArticulosMVVM basedatos;

        public static ArticulosMVVM BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new ArticulosMVVM(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Movil2Xamarin"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new VistaAgregar());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
