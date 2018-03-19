using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DungeonsandDragons.Models;
using DungeonsandDragons.Services;
using Xamarin.Forms;

namespace DungeonsandDragons.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //create datastores for mock and SQL each to manipulate DB
        private IDataStore DataStoreMock => DependencyService.Get<IDataStore>() ?? MockDataStore.Instance;
        private IDataStore DataStoreSql => DependencyService.Get<IDataStore>() ?? SQLDataStore.Instance;

        public IDataStore DataStore;

        public BaseViewModel()
        {
            DataStore = DataStoreMock;
        }

        public enum DataStoreEnum { Unknown = 0, Sql = 1, Mock = 2 }

        //switch between mock and SQL
        public void SetDataStore(DataStoreEnum data)
        {
            switch (data)
            {
                case DataStoreEnum.Mock:
                    DataStore = DataStoreMock;
                    break;

                case DataStoreEnum.Sql:
                    DataStore = DataStoreSql;
                    break;
                case DataStoreEnum.Unknown:
                default:
                    DataStore = DataStoreMock;
                    break;
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
