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
                new Hero { Id = Guid.NewGuid().ToString(), Name = "The Iron Baby", ImageLink="https://www.clker.com/cliparts/a/1/b/2/1521249390858993631imageedit_30_6056397475.med.png", Level = 2 },
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Hulk Baby", ImageLink="https://www.clker.com/cliparts/f/4/d/4/15212495851406653662imageedit_32_9581332802.med.png" , Level = 2},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Kiddo", ImageLink="https://www.clker.com/cliparts/6/1/8/0/15212496721626432074hero3.med.png" , Level = 1},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "The Spider Baby", ImageLink="https://www.clker.com/cliparts/2/7/7/9/15212497031821453567hero4.med.png" , Level = 2},
                new Hero { Id = Guid.NewGuid().ToString(), Name = "Baby Bat", ImageLink="https://www.clker.com/cliparts/d/d/0/d/1521249730174335390hero5.med.png" , Level = 1 },
                new Hero { Id = Guid.NewGuid().ToString(), Name = "The Baby Captain", ImageLink="https://www.clker.com/cliparts/a/6/4/d/1521249775910609355hero6.med.png" , Level = 2},
            };

            foreach (var data in mockHeroes)
            {
                data.updateCharacterAttributeValues();
                data.updateTotalAttributeValues();
                _heroDataset.Add(data);
            }

            var mockMonsters = new List<Monster>
            {
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Octo", ImageLink="https://www.clker.com/cliparts/b/1/b/c/15212499601676696766mon1.med.png", Level = 1 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Dingo", ImageLink="https://www.clker.com/cliparts/5/d/0/f/15212499871115384043mon2.med.png", Level = 1 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Golgappa", ImageLink="https://www.clker.com/cliparts/f/0/3/0/15212508761952413940mon3.med.png" , Level = 1},
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Kattapa", ImageLink="https://www.clker.com/cliparts/c/9/8/b/15212509041548435442mon4.med.png", Level = 1 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Rajnikanth", ImageLink="https://www.clker.com/cliparts/6/6/e/d/15212509311695532986mon5.med.png", Level = 1 },
                new Monster { Id = Guid.NewGuid().ToString(), Name = "Shakal", ImageLink="https://www.clker.com/cliparts/1/9/3/f/15212509571420675881mon6.med.png", Level = 1 },
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

        public async Task<IEnumerable<Hero>> GetAsync_HeroParty(bool forceRefresh = false)
        {
            List<Hero> dataSet = new List<Hero>();
            for (int i = 0; i < 5; i++)
            {
                dataSet.Add(new Hero(_heroDataset[i]));
            }
            return await Task.FromResult(dataSet);
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

        public async Task<IEnumerable<Monster>> GetAsync_MonsterParty(bool forceRefresh = false)
        {
            List<Monster> dataSet = new List<Monster>();
            for (int i = 0; i < 5; i++)
            {
                dataSet.Add(new Monster(_monsterDataset[i]));
            }
            return await Task.FromResult(dataSet);
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