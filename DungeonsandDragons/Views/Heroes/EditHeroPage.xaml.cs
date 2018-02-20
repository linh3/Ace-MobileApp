using System;

using Xamarin.Forms;

using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;
using Xamarin.Forms.Xaml;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditHeroPage : ContentPage
    {
        HeroDetailViewModel viewModel;
        public Hero Hero { get; set; }


        public EditHeroPage(HeroDetailViewModel viewModel)
        {
            Hero = viewModel.Hero;
            viewModel.Title = "Edit " + viewModel.Title;

            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "EditData", Hero);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PushAsync((new HeroDetailPage(new HeroDetailViewModel(Hero))));
            Navigation.RemovePage(this);
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
