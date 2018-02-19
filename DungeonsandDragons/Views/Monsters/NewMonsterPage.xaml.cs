using System;

using Xamarin.Forms;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public partial class NewMonsterPage : ContentPage
    {
        public Monster Monster { get; set; }

        public NewMonsterPage()
        {
            InitializeComponent();

            Monster = new Monster
            {
                Name = "Monster name",
                ImageLink = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddData", Monster);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
