using PM2E1201610040226.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E1201610040226
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicationSave : ContentPage
    {
        String ubicac;
         

        public UbicationSave()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listaubicacion = await App.SQLiteDB.GetUbicacionAsync();
            if (listaubicacion!= null)
            {
                lstUbicacion.ItemsSource = listaubicacion;
            }

        }

       

       

        private async void lstUbicacion_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
                var obj = (Ubicacion)e.SelectedItem;

                if (!string.IsNullOrEmpty(obj.id.ToString()))
                {
                    var ubicacion = await App.SQLiteDB.GetUbicacionByIdAsync(obj.id);
                    if (ubicacion != null)
                    {

                        Ubicacion ubicac = new Ubicacion
                        {
                            id = ubicacion.id,
                            latitud = ubicacion.latitud,
                            longitud = ubicacion.longitud,
                            descripcion = ubicacion.descripcion,
                            nombre = ubicacion.nombre
                        };

                    var mapa = new Opciones();
                    mapa.BindingContext = ubicac;
                    await Navigation.PushAsync(mapa);

                }
                }
            
        }

    }
}