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
    public partial class HeroesPage : ContentPage
    {
        HeroesViewModel viewModel;

        public HeroesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = HeroesViewModel.Instance;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var hero = args.SelectedItem as Hero;
            if (hero == null)
                return;

            await Navigation.PushAsync(new HeroDetailPage(new HeroDetailViewModel(hero)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewHeroPage());
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = null;
            if(ToolbarItems.Count > 0)
            {
                ToolbarItems.RemoveAt(0);
            }

            InitializeComponent();
            if(viewModel.Dataset.Count == 0)
            {
                viewModel.LoadDataCommand.Execute(null);
            }
            else if(viewModel.NeedsRefresh())
            {
                viewModel.LoadDataCommand.Execute((null));
            }

            BindingContext = viewModel;

        }
    }
}
