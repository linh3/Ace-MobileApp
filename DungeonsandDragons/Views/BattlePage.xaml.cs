using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;
namespace DungeonsandDragons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattlePage : ContentPage
    {

        BattleViewModel viewModel;

        //test
        public BattlePage()
        {

            InitializeComponent();

            BindingContext = viewModel = new BattleViewModel();
            viewModel.LoadDataCommand.Execute(null);

        }

        //async public void Exit_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PopAsync();
        //}

        //async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    //var monster = args.SelectedItem as Monster;
        //    //if (monster == null)
        //    //    return;

        //    //await Navigation.PushAsync(new MonsterDetailPage(new MonsterDetailViewModel(monster)));

        //    //// Manually deselect item
        //    //ItemsListView.SelectedItem = null;
        //}

     


        protected override void OnAppearing()
        {


            base.OnAppearing();
            BindingContext = null;
            if (ToolbarItems.Count > 0)
            {
                ToolbarItems.RemoveAt(0);
            }

            InitializeComponent();
                viewModel.LoadDataCommand.Execute(null);
            if (viewModel.NeedsRefresh())
            {
                viewModel.LoadDataCommand.Execute((null));
            }

            BindingContext = viewModel;

        }



        public void BattleButtonClicked(object sender, EventArgs e)
        {
            //viewModel
            if(viewModel.Battle.isAllMonstersDead() && !viewModel.Battle.isAllHeoresDead())
            {
                BattleButton.Text = "Start New Round";
                BattleButton.Clicked += NewRound;
            }
            else if(!viewModel.Battle.isAllMonstersDead() && !viewModel.Battle.isAllHeoresDead())
            {
                BattleButton.Text = "Next Turn";
                TakeTurn();
                if(viewModel.isGameOver())
                {
                    BattleButton.Text = "Gave Over";
                    BattleButton.Clicked += GameOver;
                    TextField.Text = TextField.Text + "\nGame over....";
                }else if(viewModel.Battle.isAllMonstersDead())
                {
                    BattleButton.Text = "Start New Round";
                    BattleButton.Clicked += NewRound;
                    TextField.Text += "Win. Go to next round...";
                }
                else
                {
                    TextField.Text = TextField.Text + "\n" + viewModel.nextPlayer.Name + " will attack " + viewModel.Defender.Name + " next.";
                }
            }
            //MonsterListView.SeparatorVisibility = SeparatorVisibility.Default;

        }

        async public void GameOver(object sender, EventArgs e)
        {
            Score score = new Score();
            score.ScoreTotal = viewModel.Battle.round;
            MessagingCenter.Send(this, "AddData", score);
            await Navigation.PopAsync();
        }

        public void TakeTurn()
        {
            string temp = viewModel.nextPlayer.Name + " just attacked " + viewModel.Defender.Name + " with the attack value of " + viewModel.nextPlayer.attack().ToString();
            viewModel.TakeTurn();
            InitializeComponent();
            BindingContext = viewModel;
            TextField.Text = temp;
        }

        public void NewRound(object sender, EventArgs e)
        {
            
            viewModel.NextRound();
            InitializeComponent();
            BindingContext = viewModel;
            TextField.Text = "This is Round " + viewModel.Battle.round.ToString() +"\n" + viewModel.nextPlayer.Name + " will attack " + viewModel.Defender.Name + " next.";
            //MonsterListView.SeparatorVisibility = SeparatorVisibility.Default;
            BattleButton.Text = "Next Turn";
        }

    }
}
