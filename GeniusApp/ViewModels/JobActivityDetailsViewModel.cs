using GeniusApp.ViewModels;
using GeniusApp.Models;
using GeniusApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace GeniusApp.ViewModels
{
    [QueryProperty(nameof(JobActivityModel), "JobActivityModel")]
    public partial class JobActivityDetailsViewModel : BaseViewModel
    {
        //IMap map;
        public JobActivityDetailsViewModel()
        {
            //this.map = map;
        }

        [ObservableProperty]
        JobActivityModel jobActivityModel;

        [ObservableProperty]
        bool isRefreshing;

        //[RelayCommand]
        //async Task OpenMap()
        //{
        //    try
        //    {
        //        await map.OpenAsync(Macky.Latitude, Macky.Longitude, new MapLaunchOptions
        //        {
        //            Name = Macky.Name,
        //            NavigationMode = NavigationMode.None
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Unable to launch maps: {ex.Message}");
        //        await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
        //    }
        //}
    }
}