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
    public partial class AutoBattlePage : ContentPage
    {

        AutoBattleViewModel viewModel;

        //test
        public AutoBattlePage()
        {

            InitializeComponent();

            BindingContext = viewModel = new AutoBattleViewModel();
            viewModel.LoadDataCommand.Execute(null);

        }

        async public void Exit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

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



        public void AutoBattleButtonClicked(object sender, EventArgs e)
        {
            //            bool finish = false;
            viewModel.Battle.round = 0;
            this.NewRound();
            while(!viewModel.isGameOver())
            {
                if(viewModel.Battle.isAllMonstersDead() && !viewModel.Battle.isAllHeoresDead())
                {
                    this.NewRound();
                }

                    this.TakeTurn();
            }

           // AutoBattleButton.Clicked += GameOver;
            InitializeComponent();
            BindingContext = viewModel;
            this.GameOver();
            AutoBattleButton.Text = "See Score";
            MonsterListView.SeparatorVisibility = SeparatorVisibility.Default;

           // AutoBattleButton.Clicked += GameOver;

            //viewModel
            //if(viewModel.Battle.isAllMonstersDead() && !viewModel.Battle.isAllHeoresDead())
            //{
            //    BattleButton.Text = "Start New Round";
            //    BattleButton.Clicked += NewRound;
            //}
            //else if(!viewModel.Battle.isAllMonstersDead() && !viewModel.Battle.isAllHeoresDead())
            //{
            //    BattleButton.Text = "Next Turn";
            //    TakeTurn();
            //    if(viewModel.isGameOver())
            //    {
            //        BattleButton.Text = "Gave Over";
            //        BattleButton.Clicked += GameOver;
            //        TextField.Text = TextField.Text + "\nGame over....";
            //    }else if(viewModel.Battle.isAllMonstersDead())
            //    {
            //        BattleButton.Text = "Start New Round";
            //        BattleButton.Clicked += NewRound;
            //        TextField.Text += "Win. Go to next round...";
            //    }
            //    else
            //    {
            //        TextField.Text = TextField.Text + "\n" + viewModel.nextPlayer.Name + " will attack " + viewModel.Defender.Name + " next.";
            //    }
            //}
            //MonsterListView.SeparatorVisibility = SeparatorVisibility.Default;

        }

        async public void GameOver()
        {
            Score score = new Score();
            score.ScoreTotal = viewModel.Battle.round;
            MessagingCenter.Send(this, "AddData", score);
          //  Navigation.PopAsync();
            await Navigation.PushAsync(new ScoreDetailPage(new ScoreDetailViewModel(score)));

        }

        public void TakeTurn()
        {
            viewModel.TakeTurn();
//            InitializeComponent();
  //          BindingContext = viewModel;
        }

        public void NewRound()
        {
            
            viewModel.NextRound();
//            InitializeComponent();
  //          BindingContext = viewModel;
    //        MonsterListView.SeparatorVisibility = SeparatorVisibility.Default;
        }

    }
}
