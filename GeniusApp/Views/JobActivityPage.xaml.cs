using GeniusApp.ViewModels;
using Xamarin.Forms;
using System;

namespace GeniusApp.Views
{
    public partial class JobActivityPage : ContentPage
    {

        //public JobActivityPage(JobActivitiesViewModel viewModel)
        public JobActivityPage(ShowJobActivityPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }

    }
}