using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterDetailPage : ContentPage
    {
        private MonsterDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public MonsterDetailPage()
        {
            InitializeComponent();

            var monster = new Monster
            {
                Name = "Monster 1",
                ImageLink = "This is an item description."
            };

            viewModel = new MonsterDetailViewModel(monster);
            BindingContext = viewModel;
        }

        public MonsterDetailPage(MonsterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditMonsterPage(this.viewModel));
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        async void Delete_Clicked(object sender, EventArgs e) 
        { 
            await Navigation.PushAsync(new DeleteMonsterPage(viewModel)); 
        }
    }
}
