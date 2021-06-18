using PM2E1201610040226.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM2E1201610040226
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UbicationSave());
        }

        protected async override void OnAppearing()
        {
            var locator = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(5)));

            latitud.Text = locator.Latitude.ToString();
            longitud.Text = locator.Longitude.ToString();

        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Ubicacion ubicacion = new Ubicacion
                {
                    latitud = Convert.ToDouble(latitud.Text),
                    longitud = Convert.ToDouble(longitud.Text),
                    descripcion = ubicacionC.Text,
                    nombre = nombre.Text
                };

                await App.SQLiteDB.SaveUbicacionAsync(ubicacion);
                latitud.Text = "";
                longitud.Text = "";
                ubicacionC.Text = "";
                nombre.Text = "";

                await DisplayAlert("Registro", "Datos guardados correctamente", "Ok");

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(latitud.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(longitud.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(ubicacionC.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(nombre.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

    }
}
