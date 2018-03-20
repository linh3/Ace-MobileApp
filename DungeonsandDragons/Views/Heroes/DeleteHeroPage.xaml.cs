using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteHeroPage : ContentPage
    {

        HeroDetailViewModel viewModel;    
        public Hero Hero { get; set;}

        public DeleteHeroPage(HeroDetailViewModel viewModel)   //Constructor
        {
            Hero = viewModel.Hero;
            viewModel.Title = "Delete " + viewModel.Title;
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;   // Set the data binding for the page
        }

        async void Delete_Clicked(object sender, EventArgs e)  //deletes and takes back to list page
        {
            MessagingCenter.Send(this, "DeleteData", Hero);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)  //when canceled is clicked, goes back to list page
        {
            await Navigation.PopAsync();
        }
    }
}
