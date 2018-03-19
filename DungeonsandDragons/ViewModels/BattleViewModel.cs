using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using DungeonsandDragons.Models;
using Xamarin.Forms;
using System.Collections.Generic;


namespace DungeonsandDragons.ViewModels
{
    public class BattleViewModel: BaseViewModel
    {

        public Battle Battle { get; set; }
        public Command LoadDataCommand { get; set; }
        private bool needsRefresh;
        public Character nextPlayer { get; set; }
        public Character Defender { get; set; }

        public BattleViewModel()
        {
            
            
            Title = "Battle Page";
            Battle = new Battle();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<BattlePage, Score>(this, "AddData", async (obj, data) =>
            {
                await DataStore.AddAsync_Score(data);
            });

        }

        //function call for going to next round
        public async void NextRound()
        {
            List<Monster> NewMonsterDataSet = new List<Monster>(await DataStore.GetAsync_MonsterParty(Battle.round+1));
            nextPlayer = Battle.nextRound(NewMonsterDataSet);
            Defender = Battle.whoDefenseNext();
            needsRefresh = true;
        }

        //return true if all heroes dead and declare game over
        public bool isGameOver()
        {
            return Battle.isAllHeoresDead();   
        }

        //function call for switching turns between heroes and monsters
        public void TakeTurn()
        {
            nextPlayer = Battle.takeTurn();
            Defender = Battle.whoDefenseNext();
            needsRefresh = true;
        }

        async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Battle.Heroes.Clear();
                var HeroDataSet = await DataStore.GetAsync_HeroParty(true);
                foreach (var data in HeroDataSet)
                {
                    Battle.Heroes.Add(data);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        //refreshes pages if true
        public bool NeedsRefresh()
        {
            if (needsRefresh)
            {
                needsRefresh = false;
                return true;
            }
            return false;
        }

    }
}
