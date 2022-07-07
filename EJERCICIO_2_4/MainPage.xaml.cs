using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EJERCICIO_2_4
{
    public partial class MainPage : ContentPage
    {
        MediaFile fileVideo;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnGrabarVideo_Clicked(object sender, EventArgs e)
        {
            string nameVideo = DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4";

            fileVideo = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
            {
                SaveToAlbum = true,
                Name = nameVideo,
                Directory = "VideosPM2"
            });
            if (fileVideo == null)
            {
                return;
            }

            elementVideo.Source = fileVideo.Path;
            await DisplayAlert("Confirmacion", "Video guardar en storage correctamente.", "Ok");
            fileVideo = null;
            elementVideo.Source = null;
        }
    }
}
