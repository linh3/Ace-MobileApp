﻿using System;

using Xamarin.Forms;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public partial class NewMonsterPage : ContentPage
    {
        public Monster Monster { get; set; }

        public NewMonsterPage() //Constructor
        {
            InitializeComponent();

            Monster = new Monster
            {
                Name = "Monster name",
                ImageLink = "https://www.clker.com/cliparts/6/6/e/d/15212509311695532986mon5.med.png"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e) //Saves the rew record
        {
            MessagingCenter.Send(this, "AddData", Monster);
            await Navigation.PopAsync();
        }


        async void Cancel_Clicked(object sender, EventArgs e) //takes you back to list page without saving
        {
            await Navigation.PopAsync();
        }
    }
}
