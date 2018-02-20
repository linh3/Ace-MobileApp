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

        private MonsterDetailViewModel viewModel;
        public Monster Monster { get; set;}

        public DeleteMonsterPage(MonsterDetailViewModel viewModel)
        {
            Monster = viewModel.Monster;
            viewModel.Title = "Delete " + viewModel.Title;
             InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteData", Monster);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
