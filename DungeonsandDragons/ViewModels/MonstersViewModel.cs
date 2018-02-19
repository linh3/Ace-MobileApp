using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using DungeonsandDragons.Models;
using Xamarin.Forms;

namespace DungeonsandDragons.ViewModels
{
    public class MonstersViewModel : BaseViewModel
    {
        public ObservableCollection<Monster> Dataset { get; set; }
        public Command LoadDataCommand { get; set; }
        private bool needsRefresh;
        private static MonstersViewModel _instance;

        public static MonstersViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MonstersViewModel();
                }
                return _instance;
            }
        }

        public MonstersViewModel()
        {
            Title = "Monster List";
            Dataset = new ObservableCollection<Monster>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<NewMonsterPage, Monster>(this, "AddData", async (obj, data) =>
            {
                Dataset.Add(data);
                //await DataStore.AddItemAsync(_item);
                await DataStore.AddAsync_Monster(data);
            });

            MessagingCenter.Subscribe<EditMonsterPage, Monster>(this, "EditData", async (obj, data) => {
                // Find the Item, then update it      
                var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);              
                if (myData == null)              
                {                    
                    return;             
                }              
                myData.Update(data);
                //await DataStore.UpdateItemAsync(_item);
                await DataStore.UpdateAsync_Monster(myData);
                needsRefresh = true;
            });

            MessagingCenter.Subscribe<DeleteMonsterPage, Monster>(this, "DeleteData", async (obj, data) =>             {                 Dataset.Remove(data);                 //await DataStore.DeleteAsync_Item(data);
                await DataStore.DeleteAsync_Monster(data);
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
                var dataset = await DataStore.GetAllAsync_Monster(true);
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
