using PM2E1201610040226.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E1201610040226
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Opciones : ContentPage
    {
        public Opciones()
        {
            InitializeComponent();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var ubicacion = await App.SQLiteDB.GetUbicacionByIdAsync(Convert.ToInt32(id.Text));

            if (ubicacion != null)
            {
                await App.SQLiteDB.DeleteUbicacionAsync(ubicacion);
                await DisplayAlert("Exitoso", "Datos eliminado correctamente", "Ok"); 
                id.IsVisible = false;
            }
        }

        private async void Ver_Clicked(object sender, EventArgs e)
        {
            Ubicacion ubicacion = new Ubicacion
             {
               latitud = Convert.ToDouble(latitud.Text),
               longitud = Convert.ToDouble(longitud.Text),
               descripcion =  descrip.Text,
               nombre = nombre.Text
             };

                    var mapa = new VerMapa();
                    mapa.BindingContext = ubicacion; 
                    await Navigation.PushAsync(mapa);
            await DisplayAlert("Accion", latitud.Text,"OK");
        }
    }
}