using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using DungeonsandDragons.Models;
using Xamarin.Forms;

namespace DungeonsandDragons.ViewModels
{
    public class HeroesViewModel : BaseViewModel
    {
        public ObservableCollection<Hero> Dataset { get; set; }
        public Command LoadDataCommand { get; set; }
        private bool needsRefresh;
        private static HeroesViewModel _instance;

        public static HeroesViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new HeroesViewModel();
                }
                return _instance;
            }
        }

        public HeroesViewModel()
        {
            Title = "Heroes List";
            Dataset = new ObservableCollection<Hero>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<NewHeroPage, Hero>(this, "AddData", async (obj, data) =>
            {
                Dataset.Add(data);
                //await DataStore.AddItemAsync(_item);
                await DataStore.AddAsync_Hero(data);
            });

            MessagingCenter.Subscribe<EditHeroPage, Hero>(this, "EditData", async (obj, data) => {
                // Find the Item, then update it      
                var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);              
                if (myData == null)              
                {                    
                    return;             
                }              
                myData.Update(data);
                //await DataStore.UpdateItemAsync(_item);
                await DataStore.UpdateAsync_Hero(myData);
                needsRefresh = true;
            });

            MessagingCenter.Subscribe<DeleteHeroPage, Hero>(this, "DeleteData", async (obj, data) =>             {                 Dataset.Remove(data);                 //await DataStore.DeleteAsync_Item(data);
                await DataStore.DeleteAsync_Hero(data);
                needsRefresh = true;             }); 
        }

        async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Dataset.Clear();
                var dataset = await DataStore.GetAllAsync_Hero(true);
                foreach (var data in dataset)
                {
                    Dataset.Add(data);
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
