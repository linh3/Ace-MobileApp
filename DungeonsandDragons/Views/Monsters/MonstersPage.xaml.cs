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
    public partial class MonstersPage : ContentPage
    {
        MonstersViewModel viewModel;

        public MonstersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = MonstersViewModel.Instance;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var monster = args.SelectedItem as Monster;
            if (monster == null)
                return;

            await Navigation.PushAsync(new MonsterDetailPage(new MonsterDetailViewModel(monster)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewMonsterPage());
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
