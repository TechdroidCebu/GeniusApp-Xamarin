using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GeniusApp.ViewModelss
{
    public class AboutViewModel : BaseViewMode2l
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}