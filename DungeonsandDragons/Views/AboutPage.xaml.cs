
using System;
using DungeonsandDragons.Services;
using DungeonsandDragons.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.ViewModels;
using DungeonsandDragons.Models;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void GetItems_Command(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Get", "Sure you want to Get Items from the Server?", "Yes", "No");
            if (answer)
            {
                // Call to the Item Service and have it Get the Items
                ItemsController.Instance.GetItemsFromServer();
            }
            await MockDataStore.Instance.AddAsync_Hero(null);
        }

        private async void GetItemsPost_Command(object sender, EventArgs e)
        {
            var number = 100; // Want to get 100 items from the server
            var level = 20; // Maximum number of Value
            var attribute = AttributeEnum.Unknown; // Any attribute
            var location = ItemLocationEnum.Unknown; // Any location
            var random = true;
            var updateDataBase = true;

            var myDataList = await ItemsController.Instance.GetItemsFromDungeonsandDragons(number, level, attribute, location, random, updateDataBase);

            var myOutput = string.Empty;
            foreach (var item in myDataList)
            {
                // Build up the output list by appending.
                // use "\n"; to add a line seperator at the end of each item
                myOutput += item.FormatOutput() + "\n";
            }

            var answer = await DisplayAlert("Returned List", myOutput, "Yes", "No");
        }
    }
}
