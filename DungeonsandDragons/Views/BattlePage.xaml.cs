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

        public async void OnImageHeroTapped(object sender, EventArgs args)
        {
            Image temp = (Image)sender;
            int num = Convert.ToInt32(temp.ClassId);
            string myOutput = "Name : " + viewModel.Battle.Heroes[num].Name + "\n";
            myOutput += "isAlive :" + viewModel.Battle.Heroes[num].isAlive + "\n";
            myOutput += "Level :" + viewModel.Battle.Heroes[num].Level + "\n";
            myOutput += "Experience :" + viewModel.Battle.Heroes[num].Experience + "\n";
            myOutput += "Health :" + viewModel.Battle.Heroes[num].Health + "\n";
            myOutput += "Attack :" + viewModel.Battle.Heroes[num].TotalStength + "\n";
            myOutput += "Defense :" + viewModel.Battle.Heroes[num].TotalDefense + "\n";
            myOutput += "Speed :" + viewModel.Battle.Heroes[num].TotalSpeed + "\n";
            myOutput += "\n\n";
            myOutput += "Item List:\n";
            myOutput += "   " + "Head: ";
            if(viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Head] != null){
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Head].Name + "\n";
            }else{
                myOutput += "N/A \n";
            }
            myOutput += "   " + "Necklass: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Necklass] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Necklass].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }
            myOutput += "   " + "PrimaryHand: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.PrimaryHand] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.PrimaryHand].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }
            myOutput += "   " + "OffHand: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.OffHand] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.OffHand].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }
            myOutput += "   " + "Finger: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Finger] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Finger].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }
            myOutput += "   " + "RightFinger: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.RightFinger] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.RightFinger].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }
            myOutput += "   " + "LeftFinger: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.LeftFinger] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.LeftFinger].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }
            myOutput += "   " + "Feet: ";
            if (viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Feet] != null)
            {
                myOutput += viewModel.Battle.Heroes[num].Items[(int)ItemLocationEnum.Feet].Name + "\n";
            }else
            {
                myOutput += "N/A \n";
            }


            await DisplayAlert("Hero Detail", myOutput, "Okay");
        }

        public async void OnImageMonsterTapped(object sender, EventArgs args)
        {
            Image temp = (Image)sender;
            int num = Convert.ToInt32(temp.ClassId);
            string myOutput = "Name : " + viewModel.Battle.Monsters[num].Name + "\n";
            myOutput += "isAlive :" + viewModel.Battle.Monsters[num].isAlive + "\n";
            myOutput += "Level :" + viewModel.Battle.Monsters[num].Level + "\n";
            myOutput += "Experience :" + viewModel.Battle.Monsters[num].Experience + "\n";
            myOutput += "Health :" + viewModel.Battle.Monsters[num].Health + "\n";
            myOutput += "Attack :" + viewModel.Battle.Monsters[num].TotalStength + "\n";
            myOutput += "Defense :" + viewModel.Battle.Monsters[num].TotalDefense + "\n";
            myOutput += "Speed :" + viewModel.Battle.Monsters[num].TotalSpeed + "\n";
            myOutput += "SpecialItem: ";
            if(viewModel.Battle.Monsters[num].SpecialItem != null){
                myOutput += viewModel.Battle.Monsters[num].SpecialItem.Name + "\n";
            }else{
                myOutput += "None";
            }

            await DisplayAlert("Hero Detail", myOutput, "Okay");
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
