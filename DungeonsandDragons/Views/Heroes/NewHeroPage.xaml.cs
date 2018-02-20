using System;

using Xamarin.Forms;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public partial class NewHeroPage : ContentPage
    {
        public Hero Hero { get; set; }

        public NewHeroPage()
        {
            InitializeComponent();

            Hero = new Hero
            {
                Name = "Hero name",
                ImageLink = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddData", Hero);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
