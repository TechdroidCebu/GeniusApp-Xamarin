using BitooBitImageEditor;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeniusApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageEditorPage : ContentPage
	{
        private readonly Assembly assembly;
        private List<SKBitmapImageSource> stickers;
        private int stickersCount = 15;
        public ImageEditorPage ()
		{
			InitializeComponent ();
            assembly = GetType().GetTypeInfo().Assembly;
            this.BindingContext = this;
            var display = DeviceDisplay.MainDisplayInfo;
            Config = new ImageEditorConfig(backgroundType: BackgroundType.StretchedImage, outImageHeight: (int)display.Height, outImageWidht: (int)display.Width, aspect: BBAspect.Auto);

        }


        public bool ConfigVisible { get; set; }
        public ImageEditorConfig Config { get; set; } = new ImageEditorConfig();
        public bool CanAddStickers { get; set; } = false;
        public int? OutImageHeight { get; set; } = null;
        public int? OutImageWidht { get; set; } = null;
        public bool UseSampleImage { get; set; } = true;

        public List<BBAspect> Aspects { get; } = new List<BBAspect> { BBAspect.Auto, BBAspect.AspectFill, BBAspect.AspectFit, BBAspect.Fill };
        public List<BackgroundType> BackgroundTypes { get; } = new List<BackgroundType> { BackgroundType.Transparent, BackgroundType.StretchedImage, BackgroundType.Color };
        public List<SKColor> Colors { get; } = new List<SKColor> { SKColors.Red, SKColors.Green, SKColors.Blue };

        private async void GetEditedImage_Clicked(object sender, EventArgs e)
        {
            if (!(Config?.Stickers?.Count > 0) && CanAddStickers)
                GetBitmaps(stickersCount);

            try
            {
                Config.Stickers = CanAddStickers ? stickers : null;
                Config.SetOutImageSize(OutImageHeight, OutImageWidht);

                SKBitmap bitmap = null;
                if (UseSampleImage)
                    // using (Stream stream = assembly.GetManifestResourceStream("Genius_App.genius_logo.png"))
                    using (Stream stream = assembly.GetManifestResourceStream("GeniusApp.genius_logo.png"))
                        bitmap = SKBitmap.Decode(stream);

                byte[] data = await ImageEditor.Instance.GetEditedImage(bitmap, Config);
                if (data != null)
                {
                    MyImage.Source = null;
                    MyImage.Source = ImageSource.FromStream(() => new MemoryStream(data));
                }
                data = null;
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.Message, "fewf");
            }
        }


        private void SetConfig_Clicked(object sender, EventArgs e)
        {
            ConfigVisible = !ConfigVisible;
        }

        private void Clean_Clicked(object sender, EventArgs e)
        {
            Config.DisposeStickers();
            MyImage.Source = null;
            GC.Collect();
        }

        private void GetBitmaps(int maxCount)
        {
            List<SKBitmapImageSource> _stickers = null;

            string[] resourceIDs = assembly.GetManifestResourceNames();
            int i = 0;
            foreach (string resourceID in resourceIDs)
            {
                if (resourceID.Contains("sticker") && resourceID.EndsWith(".png"))
                {
                    if (_stickers == null)
                        _stickers = new List<SKBitmapImageSource>();

                    using (Stream stream = assembly.GetManifestResourceStream(resourceID))
                    {
                        _stickers.Add(SKBitmap.Decode(stream));
                    }
                }
                i++;
                if (i > maxCount)
                    break;
            }
            stickers = _stickers;
        }

        private async void TakePhoto_Clicked(object sender, EventArgs e)
        {
            var cameraMediaOptions = new StoreCameraMediaOptions
            {
                DefaultCamera = CameraDevice.Rear,

                // Set the value to true if you want to save the photo to your public storage.
                SaveToAlbum = true,

                // Give the name of the folder you want to save to
                Directory = "Genius",

                // Give a photo name of your choice,
                // or set it to null if you want to use the default naming convention
                Name = null,

                // Set the compression quality
                // 0 = Maximum compression but worse quality
                // 100 = Minimum compression but best quality
                CompressionQuality = 100
            };
            MediaFile photo = await CrossMedia.Current.TakePhotoAsync(cameraMediaOptions);
            if (photo == null) return;
            //MyImage.Source = ImageSource.FromStream(() => photo.GetStream());


            if (!(Config?.Stickers?.Count > 0) && CanAddStickers)
                GetBitmaps(stickersCount);

            try
            {
                Config.Stickers = CanAddStickers ? stickers : null;
                Config.SetOutImageSize(OutImageHeight, OutImageWidht);

                SKBitmap bitmap = null;
                if (UseSampleImage)
                    // using (Stream stream = assembly.GetManifestResourceStream("Genius_App.genius_logo.png"))
                    //using (Stream stream = assembly.GetManifestResourceStream("GeniusApp.genius_logo.png"))
                        bitmap = SKBitmap.Decode(photo.GetStream());

                byte[] data = await ImageEditor.Instance.GetEditedImage(bitmap, Config);
                if (data != null)
                {
                    MyImage.Source = null;
                    MyImage.Source = ImageSource.FromStream(() => new MemoryStream(data));
                }
                data = null;
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.Message, "Close");
            }
        }
    }
}