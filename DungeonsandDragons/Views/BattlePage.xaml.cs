using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DungeonsandDragons
{
    public partial class BattlePage : ContentPage
    {
        //test
        public BattlePage()
        {
            InitializeComponent();
        }

        async public void Exit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
           }
    }
}
