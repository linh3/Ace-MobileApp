using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Character = DungeonsandDragons.Models.Character;
using DungeonsandDragons.Models;

namespace DungeonsandDragons{
    public sealed class MockDataStore : IDataStore
    {

        // Make this a singleton so it only dexist one time because holds all the data records in memory
        private static MockDataStore _instance;

        public static MockDataStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockDataStore();
                }
                return _instance;
            }
        }

        private List<Item> _itemDataset = new List<Item>();
        private List<Hero> _heroDataset = new List<Hero>();
        private List<Monster> _monsterDataset = new List<Monster>();
        private List<Score> _scoreDataset = new List<Score>();

        public MockDataStore()
        {
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "First item", Description="This is 1 item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Second item", Description="This is 2 item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Third item", Description="This is 3 item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Fourth item", Description="This is 4 item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Fifth item", Description="This is 5 item description." },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Sixth item", Description="This is 6 item description." },
            };

            foreach (var data in mockItems)
            {
                _itemDataset.Add(data);
            }

            var mockHeroes = new List<Hero>
            {
                new Hero { Id = Guid.NewGuid().ToString(), Name = "First Hero", ImageLink="An image link to Hero1.", Level = 1 },
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Second Hero", ImageLink="An image link to Hero2." , Level = 1},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Third Hero", ImageLink="An image link to Hero3." , Level = 2},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Fourth Hero", ImageLink="An image link to Hero4." , Level = 2},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Fifth Hero", ImageLink="An image link to Hero5." , Level = 3},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Sixth Hero", ImageLink="An image link to Hero6." , Level = 3},
            };

            foreach (var data in mockHeroes)
            {
                data.updateCharacterAttributeValues();
                data.updateTotalAttributeValues();
                _heroDataset.Add(data);
            }

            var mockMonsters = new List<Monster>
            {
                new Monster { Id = Guid.NewGuid().ToString(), Name = "First Monster", ImageLink="This is the image link for Monster 1", Level = 3 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Second Monster", ImageLink="This is the image link for Monster 2", Level = 19 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Third Monster", ImageLink="This is the image link for Monster 3" , Level = 5},
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Fourth Monster", ImageLink="This is the image link for Monster 4", Level = 7 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Fifth Monster", ImageLink="This is the image link for Monster 5", Level = 13 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Sixth Monster", ImageLink="This is the image link for Monster 6", Level = 15 },
            };

            foreach (var data in mockMonsters)
            {
                data.updateCharacterAttributeValues();
                data.updateTotalAttributeValues();
                _monsterDataset.Add(data);
            }

            var mockScores = new List<Score>
            {
                new Score { Id = Guid.NewGuid().ToString(), Name = "First Score", ScoreTotal = 111},
                new Score { Id = Guid.NewGuid().ToString(), Name = "Second Score", ScoreTotal = 222},
                new Score { Id = Guid.NewGuid().ToString(), Name = "Third Score", ScoreTotal = 333},
                new Score { Id = Guid.NewGuid().ToString(), Name = "Fourth Score", ScoreTotal = 444},
                new Score { Id = Guid.NewGuid().ToString(), Name = "Fifth Score", ScoreTotal = 555},
                new Score { Id = Guid.NewGuid().ToString(), Name = "Sixth Score", ScoreTotal = 666},
            };

            foreach (var data in mockScores)
            {
                _scoreDataset.Add(data);
            }

        }

        // Item
        public async Task<bool> AddAsync_Item(Item data)
        {
            _itemDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Item(Item data)
        {
            var myData = _itemDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _itemDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetAsync_Item(string id)
        {
            return await Task.FromResult(_itemDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false)
        {
            return await Task.FromResult(_itemDataset);
        }


        // Hero
        public async Task<bool> AddAsync_Hero(Hero data)
        {
            _heroDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Hero(Hero data)
        {
            var myData = _heroDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Hero(Hero data)
        {
            var myData = _heroDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _heroDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Hero> GetAsync_Hero(string id)
        {
            return await Task.FromResult(_heroDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Hero>> GetAllAsync_Hero(bool forceRefresh = false)
        {
            return await Task.FromResult(_heroDataset);
        }


        //Monster
        public async Task<bool> AddAsync_Monster(Monster data)
        {
            _monsterDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Monster(Monster data)
        {
            var myData = _monsterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Monster(Monster data)
        {
            var myData = _monsterDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _monsterDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Monster> GetAsync_Monster(string id)
        {
            return await Task.FromResult(_monsterDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false)
        {
            return await Task.FromResult(_monsterDataset);
        }


        // Score
        public async Task<bool> AddAsync_Score(Score data)
        {
            _scoreDataset.Add(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync_Score(Score data)
        {
            var myData = _scoreDataset.FirstOrDefault(arg => arg.Id == data.Id);
            if (myData == null)
            {
                return false;
            }

            myData.Update(data);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync_Score(Score data)
        {
            var myData = _scoreDataset.FirstOrDefault(arg => arg.Id == data.Id);
            _scoreDataset.Remove(myData);

            return await Task.FromResult(true);
        }

        public async Task<Score> GetAsync_Score(string id)
        {
            return await Task.FromResult(_scoreDataset.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false)
        {
            return await Task.FromResult(_scoreDataset);
        }

    }
}