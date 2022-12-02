
using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged;


namespace GeniusApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        double _LocationLatitude;

        [ObservableProperty]
        double _LocationLongitude;

        public bool IsNotBusy => IsBusy;

   
    }
}