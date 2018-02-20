using System;

using Xamarin.Forms;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public partial class NewScorePage : ContentPage
    {
        public Score Score { get; set; }

        public NewScorePage()
        {
            InitializeComponent();

            Score = new Score
            {
                Name = "Score Value",
                ScoreTotal = 00
            };

            BindingContext = this;
        }


        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddData", Score);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
