using GeniusApp.Models;
using GeniusApp.Services;
//using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GeniusApp.Views;
using Xamarin.Forms;
using Xamarin.Essentials;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GeniusApp.ViewModels
{
    public partial class ShowJobActivityPageViewModel: BaseViewModel
    {
        JobActivityService jobActivityService;
        //IConnectivity connectivity;
        //IGeolocation geolocation;

        #region Properties

        public ObservableCollection<JobActivityModel> JobActivities { get; set; } = new ObservableCollection<JobActivityModel>();
        private readonly JobActivityDBService _jobActivityDBService;
        #endregion

        #region Constructor
        public ShowJobActivityPageViewModel(JobActivityService jobActivityService)
        {
            this.jobActivityService = jobActivityService;
            //this.connectivity = connectivity;
            //this.geolocation = geolocation;
            _jobActivityDBService = new JobActivityDBService();
        }
        #endregion


        [RelayCommand]
        public async void GoToHome()
        {
            //await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [ObservableProperty]
        bool isRefreshing;
        #region Methods
        [RelayCommand]
        public async void ShowJobActivity()
        {
            if (IsBusy)
                return;

            //IsBusy = true;
            var allJobActivities = _jobActivityDBService.GetAllJobActivities();

            if (allJobActivities?.Count > 0)
            {
                JobActivities.Clear();
                foreach (var jactivity in allJobActivities)
                {
                    JobActivities.Add(jactivity);
                }

                //IsBusy = false;
                //IsRefreshing = false;
            }
            else
            {
                await Shell.Current.DisplayAlert("Database Empty!", $"Please Sync from Online Database.", "OK");
                //IsBusy = false;
                //IsRefreshing = false;
                return;             
            }

          
        }
        #endregion

        [RelayCommand]
        async Task GoToDetails(JobActivityModel jobActivityModel)
        {
            //Set Current JA_ID Globally
            Preferences.Set("JA_ID", jobActivityModel.jaId.ToString());


            if (jobActivityModel == null)
                return;

            //await Shell.Current.GoToAsync(nameof(JobActivityDetailsPage), true, new Dictionary<string, object>
            //{
            //    {"JobActivityModel", jobActivityModel }
            //});
        }


        [RelayCommand]
        public async void SyncJobActivity()
        {
            var current = NetworkAccess.Internet;
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

                //IsBusy = true;
                var jobActivities = await jobActivityService.GetJobActivities();

                if (JobActivities.Count != 0)
                    JobActivities.Clear();


                _jobActivityDBService.DropAndCreateTableJobActivity();
                foreach (var jactivity in jobActivities)
                {
                    JobActivities.Add(jactivity);
                    _jobActivityDBService.InsertJobActivity(jactivity);
                }
                
                await Shell.Current.DisplayAlert("Info!", $"Successfully Sync Online!", "OK");

            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to get Job Activities: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                //IsBusy = false;
                //IsRefreshing = false;
            }
        }


        













        //    #region Commands
        //    public ICommand NavigateToAddEmployeePageCommand => new Command(async () =>
        //    {
        //        await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage());
        //    });


        //    public ICommand SelectedEmployeeCommand => new Command<EmployeeModel>(async (employee) =>
        //    {
        //        string res = await App.Current.MainPage.DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

        //        switch (res)
        //        {
        //            case "Update":
        //                await App.Current.MainPage.Navigation.PushAsync(new AddEmployeePage(employee));
        //                break;
        //            case "Delete":
        //                int del = _employeeService.DeleteEmployee(employee);
        //                if (del > 0)
        //                {
        //                    Employees.Remove(employee);
        //                }
        //                break;
        //        }
        //    });
        //    #endregion

    }
}