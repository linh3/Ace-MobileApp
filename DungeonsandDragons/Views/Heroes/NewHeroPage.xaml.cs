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
                ImageLink = "This is an item description.",
                Level = 0,
                Strength = 0,
                Defense = 0,
                Speed = 0
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
