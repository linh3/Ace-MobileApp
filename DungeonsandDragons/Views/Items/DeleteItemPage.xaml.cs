using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteItemPage : ContentPage
    {

        // private ItemDetailViewModel _viewModel;
        public Item item { get; set; }

        public DeleteItemPage(ItemDetailViewModel viewModel)
        {
            item = viewModel.Item;
            viewModel.Title = "Delte " + viewModel.Title;
            InitializeComponent();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteData", item);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
