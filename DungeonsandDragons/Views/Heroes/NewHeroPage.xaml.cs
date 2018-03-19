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
                ImageLink = "https://www.clker.com/cliparts/f/4/d/4/15212495851406653662imageedit_32_9581332802.med.png",
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
