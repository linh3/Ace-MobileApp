using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DungeonsandDragons.Models;
using DungeonsandDragons.ViewModels;

namespace DungeonsandDragons.Services
{
    public sealed class SQLDataStore : IDataStore
    {

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static SQLDataStore _instance;

        public static SQLDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDataStore();
                }
                return _instance;
            }
        }

        private SQLDataStore()
        {
            CreateTables();
        }

        // Create the Database Tables
        private void CreateTables()
        {
            App.Database.CreateTableAsync<Score>().Wait();
            App.Database.CreateTableAsync<Item>().Wait();
            App.Database.CreateTableAsync<Monster>().Wait();
            App.Database.CreateTableAsync<Hero>().Wait();


        }

        // Delete the Datbase Tables by dropping them
        private void DeleteTables()
        {
            App.Database.DropTableAsync<Item>().Wait();
            App.Database.DropTableAsync<Hero>().Wait();
            App.Database.DropTableAsync<Monster>().Wait();
            App.Database.DropTableAsync<Score>().Wait();
        }

        // Tells the View Models to update themselves.
        private void NotifyViewModelsOfDataChange()
        {
            ItemsViewModel.Instance.SetNeedsRefresh(true);
            MonstersViewModel.Instance.SetNeedsRefresh(true);
            HeroesViewModel.Instance.SetNeedsRefresh(true);
            ScoreViewModel.Instance.SetNeedsRefresh(true);
        }

        public void InitializeDatabaseNewTables()
        {
            // Delete the tables
            DeleteTables();

            // make them again
            CreateTables();

            // Populate them
            InitilizeSeedData();

            // Tell View Models they need to refresh
            NotifyViewModelsOfDataChange();
        }

        private async void InitilizeSeedData()
        {

            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "First item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Third item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description = "This is an item description." });
            await AddAsync_Item(new Item { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description = "This is an item description." });


            await AddAsync_Hero(new Hero { Id = Guid.NewGuid().ToString(), Name = "First Hero", ImageLink="This is an Hero description.", Level = 1 });
            await AddAsync_Hero(new Hero { Id = Guid.NewGuid().ToString(), Name = "Second Hero", ImageLink="This is an Hero description." , Level = 1});
            await AddAsync_Hero(new Hero { Id = Guid.NewGuid().ToString(), Name = "Third Hero", ImageLink="This is an Hero description." , Level = 2});
            await AddAsync_Hero(new Hero { Id = Guid.NewGuid().ToString(), Name = "Fourth Hero", ImageLink="This is an Hero description." , Level = 2});
            await AddAsync_Hero(new Hero { Id = Guid.NewGuid().ToString(), Name = "Fifth Hero", ImageLink="This is an Hero description." , Level = 3});
            await AddAsync_Hero(new Hero { Id = Guid.NewGuid().ToString(), Name = "Sixth Hero", ImageLink="This is an Hero description." , Level = 3});

            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "First Monster", ImageLink="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Second Monster", ImageLink="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Third Monster", ImageLink="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Fourth Monster", ImageLink="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Fifth Monster", ImageLink="This is an Monster description." });
            await AddAsync_Monster(new Monster { Id = Guid.NewGuid().ToString(), Name = "Sixth Monster", ImageLink="This is an Monster description." });

            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "First Score", ScoreTotal= 111});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Second Score", ScoreTotal= 222 });
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Third Score", ScoreTotal= 333});
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Fourth Score", ScoreTotal = 444 });
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Fifth Score", ScoreTotal = 555 });
            await AddAsync_Score(new Score { Id = Guid.NewGuid().ToString(), Name = "Sixth Score", ScoreTotal = 666 });

        }

        // Item

        // Add InsertUpdateAsync_Item Method

        // Check to see if the item exists
                // Add your code here.

        // If it does not exist, then Insert it into the DB
                // Add your code here.
                // return true;

        // If it does exist, Update it into the DB
                // Add your code here
                // return true;

        // If you got to here then return false;

        public async Task<bool> InsertUpdateAsync_Item(Item data)
        {

            // Check to see if the item exist
            var oldData = await GetAsync_Item(data.Id);
            if (oldData == null)
            {
                // If it does not exist, add it to the DB
                var InsertResult = await App.Database.InsertAsync(data);
                if (InsertResult == 1)
                {
                    return true;
                }
            }

            // Compare it, if different update in the DB
            var UpdateResult = await UpdateAsync_Item(data);
            if (UpdateResult)
            {
                return true;
            }

            return false;
        }


        // Item
        public async Task<bool> AddAsync_Item(Item data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            // Need to add a try catch here, to catch when looking for something that does not exist in the db...
            try
            {
                var result = await App.Database.GetAsync<Item>(id);
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            var result = await App.Database.Table<Item>().ToListAsync();
            return result;
        }


        // Hero
        public async Task<bool> AddAsync_Hero(Hero data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Hero(Hero data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Hero(Hero data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Hero> GetAsync_Hero(string id)
        {
            var result = await App.Database.GetAsync<Hero>(id);
            return result;
        }

        public async Task<IEnumerable<Hero>> GetAllAsync_Hero(bool forceRefresh = false)
        {
            var result = await App.Database.Table<Hero>().ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Hero>> GetAsync_HeroParty(bool forceRefresh = false)
        {
            List<Hero> dataSet = new List<Hero>();
            for (int i = 0; i < 5; i++)
            {
           //     dataSet.Add(new Hero(_heroDataset[i]));
            }
            return await Task.FromResult(dataSet);
        }


        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            var result = await App.Database.GetAsync<Monster>(id);
            return result;
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            var result = await App.Database.Table<Monster>().ToListAsync();
            return result;

        }

        public async Task<IEnumerable<Monster>> GetAsync_MonsterParty(bool forceRefresh = false)
        {
            List<Monster> dataSet = new List<Monster>();
            for (int i = 0; i < 5; i++)
            {
              //  dataSet.Add(new Monster(_monsterDataset[i]));
            }
            return await Task.FromResult(dataSet);
        }


        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            var result = await App.Database.InsertAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            var result = await App.Database.UpdateAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            var result = await App.Database.DeleteAsync(data);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public async Task<Score> GetAsync_Score(string id)
        {
            var result = await App.Database.GetAsync<Score>(id);
            return result;
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            var result = await App.Database.Table<Score>().ToListAsync();
            return result;

        }
    }
}