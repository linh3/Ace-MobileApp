using System;

using Xamarin.Forms;

using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;
using Xamarin.Forms.Xaml;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditScorePage : ContentPage
    {
        ScoreDetailViewModel viewModel;
        public Score Score { get; set; }


        public EditScorePage(ScoreDetailViewModel viewModel) //Constructor
        {
            Score = viewModel.Score;
            viewModel.Title = "Edit " + viewModel.Title;

            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }



        async void Save_Clicked(object sender, EventArgs e) //Saves the new updates
        {
            MessagingCenter.Send(this, "EditData", Score);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PushAsync((new ScoreDetailPage(new ScoreDetailViewModel(Score))));
            Navigation.RemovePage(this);
        }



        async void Cancel_Clicked(object sender, EventArgs e) //takes you back to list page without saving
        {
            await Navigation.PopAsync();
        }
    }
}
