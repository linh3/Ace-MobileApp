using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScorePage : ContentPage
    {
        ScoreViewModel viewModel;

        public ScorePage() //Constructor
        {
            InitializeComponent();

            BindingContext = viewModel = ScoreViewModel.Instance;
        }



        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) // takes you to the score detail page when clicked
        {
            var score = args.SelectedItem as Score;
            if (score == null)
                return;

            await Navigation.PushAsync(new ScoreDetailPage(new ScoreDetailViewModel(score)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e) //takes you to the add new score page
        {
            await Navigation.PushAsync(new NewScorePage());
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = null;
            if (ToolbarItems.Count > 0)
            {
                ToolbarItems.RemoveAt(0);
            }

            InitializeComponent();
            if (viewModel.Dataset.Count == 0)
            {
                viewModel.LoadDataCommand.Execute(null);
            }
            else if (viewModel.NeedsRefresh())
            {
                viewModel.LoadDataCommand.Execute((null));
            }

            BindingContext = viewModel;

        }
    }
}
