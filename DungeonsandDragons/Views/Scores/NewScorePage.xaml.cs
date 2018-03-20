using System;

using Xamarin.Forms;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public partial class NewScorePage : ContentPage
    {
        public Score Score { get; set; }

        public NewScorePage() //Constructor
        {
            InitializeComponent();

            Score = new Score
            {
                Name = "Score Value",
                ScoreTotal = 00
            };

            BindingContext = this;
        }


        async void Save_Clicked(object sender, EventArgs e) //saves the new record
        {
            MessagingCenter.Send(this, "AddData", Score);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e) //takes you back to scorelist page withoutsaving
        {
            await Navigation.PopAsync();
        }
    }
}
