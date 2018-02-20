﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DungeonsandDragons
{
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
        }
        async public void StartBattle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BattlePage());
        }
    }
}