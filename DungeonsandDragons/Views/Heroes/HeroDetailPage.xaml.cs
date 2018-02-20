using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroDetailPage : ContentPage
    {
        private HeroDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public HeroDetailPage()
        {
            InitializeComponent();

            var hero = new Hero
            {
                Name = "Hero 1",
                ImageLink = "This is an item description.",
                Level = 0,
                Strength = 0,
                Defense = 0,
                Speed = 0
            };

            viewModel = new HeroDetailViewModel(hero);
            BindingContext = viewModel;
        }

        public HeroDetailPage(HeroDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditHeroPage(this.viewModel));
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }

        async void Delete_Clicked(object sender, EventArgs e) 
        { 
            await Navigation.PushAsync(new DeleteHeroPage(viewModel)); 
        }
    }
}
