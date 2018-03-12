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
    public class AutoBattleViewModel: BaseViewModel
    {

        public Battle Battle { get; set; }
        public Command LoadDataCommand { get; set; }
        private bool needsRefresh;
        public Character nextPlayer { get; set; }
        public Character Defender { get; set; }
        //private static AutoBattleViewModel _instance;

        //public static AutoBattleViewModel Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new AutoBattleViewModel();
        //        }
        //        return _instance;
        //    }
        //}


        public AutoBattleViewModel()
        {
            
            
            Title = "AutoBattle Page";
            Battle = new Battle();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<AutoBattlePage, Score>(this, "AddData", async (obj, data) =>
            {
                await DataStore.AddAsync_Score(data);
            });

        }

        public async void NextRound()
        {
            List<Monster> NewMonsterDataSet = new List<Monster>(await DataStore.GetAsync_MonsterParty(true));
            nextPlayer = Battle.nextRound(NewMonsterDataSet);
            Defender = Battle.whoDefenseNext();
            needsRefresh = true;
        }

        public bool isGameOver()
        {
            return Battle.isAllHeoresDead();   
        }

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
