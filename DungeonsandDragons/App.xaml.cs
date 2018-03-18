using System;
using SQLite;

using Xamarin.Forms;
using DungeonsandDragons.Services;

namespace DungeonsandDragons
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";

     

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<SQLDataStore>();

            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());
        }

        static SQLiteAsyncConnection _database = new SQLiteAsyncConnection("CRUDiDatebase.db3");

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("CRUDiDatabase.db3"));
                }
                return _database;
            }
        }

    }
}
