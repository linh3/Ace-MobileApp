using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using DungeonsandDragons.Models;
using Xamarin.Forms;

namespace DungeonsandDragons.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Dataset { get; set; }
        public Command LoadDataCommand { get; set; }
        private bool needsRefresh;
        private static ItemsViewModel _instance;

        public static ItemsViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ItemsViewModel();
                }
                return _instance;
            }
        }

        public ItemsViewModel()
        {
            Title = "Item List";
            Dataset = new ObservableCollection<Item>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddData", async (obj, data) =>
            {
                Dataset.Add(data);
                //await DataStore.AddItemAsync(_item);
                await DataStore.AddAsync_Item(data);
            });

            MessagingCenter.Subscribe<EditItemPage, Item>(this, "EditData", async (obj, data) => {
                // Find the Item, then update it      
                var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);              
                if (myData == null)              
                {                    
                    return;             
                }              
                myData.Update(data);
                //await DataStore.UpdateItemAsync(_item);
                await DataStore.UpdateAsync_Item(myData);
                needsRefresh = true;
            });

            MessagingCenter.Subscribe<DeleteItemPage, Item>(this, "DeleteData", async (obj, data) =>             {                 Dataset.Remove(data);                 //await DataStore.DeleteAsync_Item(data);
                await DataStore.DeleteAsync_Item(data);
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
                var dataset = await DataStore.GetAllAsync_Item(true);
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
