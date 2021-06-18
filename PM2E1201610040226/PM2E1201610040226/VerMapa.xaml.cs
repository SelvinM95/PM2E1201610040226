using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E1201610040226
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerMapa : ContentPage
    {
        public VerMapa()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Pin ubicacion = new Pin();
            ubicacion.Label = "San Pedro Sula";
            ubicacion.Address = "Cerca de UTH";
            ubicacion.Position = new Position(15.5510539, -88.0109923);
            mapas.Pins.Add(ubicacion);

            var localization = await Geolocation.GetLastKnownLocationAsync();

            if (localization == null)
            {
                localization = await Geolocation.GetLocationAsync();
            }

            mapas.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(localization.Latitude, localization.Longitude), Distance.FromKilometers(1)));
        }
                }
    }