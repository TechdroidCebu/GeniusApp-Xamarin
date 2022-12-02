using GeniusApp.ViewModels;
using System.Windows.Input;
using GeniusApp.Views;
using GeniusApp.Messages;
using System;
using Xamarin.Forms;

namespace GeniusApp.Views
{
    public partial class JobActivityDetailsPage : ContentPage
    {
        public ICommand NavigateCommand { get; set; }
        public JobActivityDetailsPage(JobActivityDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }


       // async void btnAddNode_Clicked(object sender, EventArgs e)
       // {
            //var ja_id = lblJAId.Text.Replace("JA ID:", "");
            //WeakReferenceMessenger.Default.Send(new SetJaIDMessages(ja_id));
            //await Shell.Current.GoToAsync(nameof(AddNodePage));
            //await Shell.Current.GoToAsync($"{nameof(AddNodePage)}");
            //await Shell.Current.GoToAsync($"{nameof(AddNodePage)}?JA_Id={ja_id}");
        //}
    }
}