using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteMonsterPage : ContentPage
    {

       // private MonsterDetailViewModel _viewModel;
        public Monster monster { get; set;}

        public DeleteMonsterPage(MonsterDetailViewModel viewModel)
        {
            monster = viewModel.Monster;
            viewModel.Title = "Delte " + viewModel.Title;
             InitializeComponent();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteData", monster);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
