using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteScorePage : ContentPage
    {

        // private MonsterDetailViewModel _viewModel;
        public Score score { get; set; }

        public DeleteScorePage(ScoreDetailViewModel viewModel)
        {
            score = viewModel.Score;
            viewModel.Title = "Delete " + viewModel.Title;
            InitializeComponent();
        }


        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteData", score);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
