using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GeniusApp.ViewModelss;
using GeniusApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Forms;
using GeniusApp.Models;
using System.Collections.Generic;
using Xamarin.Essentials;
using GeniusApp.Views;
using System;

namespace GeniusApp.ViewModels
{

public partial class JobActivitiesViewModel : BaseViewModel
{
    public ObservableCollection<JobActivityModel> JobActivities { get; } =  new ObservableCollection<JobActivityModel>();
    JobActivityService jobActivityService;
    //IConnectivity connectivity;
    //IGeolocation geolocation;

    //public JobActivity Item
    //{
    //    get => BindingContext as JobActivity;
    //    set => BindingContext = value;
    //}

    //JobActivityItemDatabase database;


    //JobActivitySQL item;
    //public JobActivitySQL Item
    //{
    //    get; set;
    //}
    //SQLiteAsyncConnection db;
    //JobActivityItemDatabase database;
    private readonly JobActivityDBService _jobActivityDBService;
    public JobActivitiesViewModel(JobActivityService jobActivityService)
    {
        Title = "Job Activity";
        this.jobActivityService = jobActivityService;
        //this.connectivity = connectivity;
        //this.geolocation = geolocation;
        _jobActivityDBService = new JobActivityDBService();

    }

    [RelayCommand]
    async Task GoToDetails(JobActivityModel jobActivity)
    {
        if (jobActivity == null)
            return;

        //await Shell.Current.GoToAsync(nameof(JobActivityDetailsPage), true, new Dictionary<string, object>
        //{
        //    {"JobActivity", jobActivity }
        //});
    }

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    async Task GetJobActivityAsync()
    {
        if (IsBusy)
            return;

        try
        {
            //if (connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    await Shell.Current.DisplayAlert("No connectivity!",
            //        $"Please check internet and try again.", "OK");
            //    return;
            //}

            IsBusy = true;
            var jobActivities = await jobActivityService.GetJobActivities();

            if (JobActivities.Count != 0)
                JobActivities.Clear();

            foreach (var jactivity in jobActivities)
                JobActivities.Add(jactivity);

            if(JobActivities.Count == 0)
            {
                await Shell.Current.DisplayAlert("Database Info!",
                        $"Please Sync from Online Database.", "OK");
                return;
            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Job Activities: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }



    [RelayCommand]
    async Task SyncDataAsync()
    {
            var current = Connectivity.NetworkAccess;
            if (IsBusy)
            return;

        try
        {
            if (current != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }




            IsBusy = true;
            var jobActivities = await jobActivityService.GetJobActivities();

            if (JobActivities.Count != 0)
                JobActivities.Clear();

            

            foreach (var jactivity in jobActivities)
            {
                    JobActivities.Add(jactivity);
                    _jobActivityDBService.InsertJobActivity(jactivity);
            }      
               




            // else we DO have an entry, and you can see all the parts of it
            // by doing basic debug inspection in the watch window 



            // Get an absolute path to the database file
            //var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");
            //    var Database = new SQLiteAsyncConnection(databasePath);
            //    await Database.CreateTableAsync<JobActivitySQL>();



        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Job Activities: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }




    //[RelayCommand]
    //async Task GetClosestMacky()
    //{
    //    if (IsBusy || JobActivities.Count == 0)
    //        return;

    //    try
    //    {
    //        // Get cached location, else get real location.
    //        var location = await geolocation.GetLastKnownLocationAsync();
    //        if (location == null)
    //        {
    //            location = await geolocation.GetLocationAsync(new GeolocationRequest
    //            {
    //                DesiredAccuracy = GeolocationAccuracy.Medium,
    //                Timeout = TimeSpan.FromSeconds(30)
    //            });
    //        }

    //        // Find closest Macky to us
    //        var first = JobActivities.OrderBy(m => location.CalculateDistance(
    //            new Location(m.Latitude, m.Longitude), DistanceUnits.Miles))
    //            .FirstOrDefault();

    //        await Shell.Current.DisplayAlert("", first.Name + " " +
    //            first.Location, "OK");

    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine($"Unable to query location: {ex.Message}");
    //        await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
    //    }
    //}
}

}

