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
    public partial class GamePage : ContentPage
    {
        AutoBattleViewModel viewModel;

        public GamePage()
        {
            BindingContext = viewModel = new AutoBattleViewModel();
            viewModel.LoadDataCommand.Execute(null);
            InitializeComponent();
        }
        async public void StartBattle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattlePage());
        }

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
     

        async public void GameOver()
        {
            Score score = new Score();
            score.ScoreTotal = viewModel.Battle.round;
            MessagingCenter.Send(this, "AddData", score);
            await Navigation.PushAsync(new ScoreDetailPage(new ScoreDetailViewModel(score)));

        }

        public void TakeTurn()
        {
            viewModel.TakeTurn();
        }

        public void NewRound()
        {

            viewModel.NextRound();
        }
        public void AutoBattleButtonClicked(object sender, EventArgs e)
        {
            viewModel.Battle.round = 0;
            this.NewRound();
            while (!viewModel.isGameOver())
            {
                if (viewModel.Battle.isAllMonstersDead() && !viewModel.Battle.isAllHeoresDead())
                {
                    this.NewRound();
                }

                this.TakeTurn();
            }

            InitializeComponent();
            BindingContext = viewModel;
            this.GameOver();

        }
    }
}
