using System;

using Xamarin.Forms;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage() //constructor
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e) //adds new record
        {
            MessagingCenter.Send(this, "AddData", Item);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)  //takes you to Item list page without saving
        {
            await Navigation.PopAsync();
        }
    }
}
