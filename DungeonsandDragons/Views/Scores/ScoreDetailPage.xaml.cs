using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreDetailPage : ContentPage
    {
        private ScoreDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ScoreDetailPage()
        {
            InitializeComponent();

            var score = new Score
            {
                Name = "Score 1",
                ScoreTotal = 00
            };

            viewModel = new ScoreDetailViewModel(score);
            BindingContext = viewModel;
        }



        public ScoreDetailPage(ScoreDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditScorePage(this.viewModel));
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteScorePage(viewModel));
        }
    }
}
