using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using DungeonsandDragons.Models;
using Xamarin.Forms;

namespace DungeonsandDragons.ViewModels
{
    public class ScoreViewModel : BaseViewModel
    {
        public ObservableCollection<Score> Dataset { get; set; }
        public Command LoadDataCommand { get; set; }
        private bool needsRefresh;
        private static ScoreViewModel _instance;

        public static ScoreViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScoreViewModel();
                }
                return _instance;
            }
        }

        public ScoreViewModel()
        {
            Title = "Score List";
            Dataset = new ObservableCollection<Score>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            MessagingCenter.Subscribe<NewScorePage, Score>(this, "AddData", async (obj, data) =>
            {
                Dataset.Add(data);
                //await DataStore.AddItemAsync(_item);
                await DataStore.AddAsync_Score(data);
            });

            MessagingCenter.Subscribe<EditScorePage, Score>(this, "EditData", async (obj, data) => {
                // Find the Item, then update it      
                var myData = Dataset.FirstOrDefault(arg => arg.Id == data.Id);
                if (myData == null)
                {
                    return;
                }
                myData.Update(data);
                //await DataStore.UpdateItemAsync(_item);
                await DataStore.UpdateAsync_Score(myData);
                needsRefresh = true;
            });

            MessagingCenter.Subscribe<DeleteScorePage, Score>(this, "DeleteData", async (obj, data) =>
            {
                Dataset.Remove(data);
                //await DataStore.DeleteAsync_Item(data);
                await DataStore.DeleteAsync_Score(data);
                needsRefresh = true;
            });
        }

        async Task ExecuteLoadDataCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Dataset.Clear();
                var dataset = await DataStore.GetAllAsync_Score(true);
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
