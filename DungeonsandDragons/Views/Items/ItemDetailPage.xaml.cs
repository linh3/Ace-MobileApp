using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Name = "Item 1",
                Description = "This is an item description.",
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;  // Set the data binding for the page
        }

        async void Edit_Clicked(object sender, EventArgs e)  //takes you to itemEdit page
        {
            await Navigation.PushAsync(new EditItemPage(this.viewModel));
        }

        async void Cancel_Clicked(object sender, EventArgs e)  //takes you to Item list page
        {
            await Navigation.PopAsync();

        }

        async void Delete_Clicked(object sender, EventArgs e)  //takes you to itemdelete page
        {
            await Navigation.PushAsync(new DeleteItemPage(viewModel));
        }
    }
}
