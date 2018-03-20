using System;

using Xamarin.Forms;

using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;
using Xamarin.Forms.Xaml;

namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditMonsterPage : ContentPage
    {
        MonsterDetailViewModel viewModel;
        public Monster Monster { get; set; }


        public EditMonsterPage(MonsterDetailViewModel viewModel) //Constructor
        {
            Monster = viewModel.Monster;
            viewModel.Title = "Edit " + viewModel.Title;

            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)  //Saves the updated data
        {
            MessagingCenter.Send(this, "EditData", Monster);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            await Navigation.PushAsync((new MonsterDetailPage(new MonsterDetailViewModel(Monster))));
            Navigation.RemovePage(this);
        }



        async void Cancel_Clicked(object sender, EventArgs e) //takes you back to monster list page without saving the changes
        {
            await Navigation.PopAsync();
        }
    }
}
