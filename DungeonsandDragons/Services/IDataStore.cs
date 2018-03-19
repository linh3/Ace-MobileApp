using System.Collections.Generic;
using System.Threading.Tasks;
using DungeonsandDragons.Models;

namespace DungeonsandDragons
{
    //add, update, delete and get methods for items,heroes,monsters and scores
    public interface IDataStore
    {
        Task<bool> AddAsync_Item(Item data);
        Task<bool> UpdateAsync_Item(Item data);
        Task<bool> DeleteAsync_Item(Item data);
        Task<Item> GetAsync_Item(string id);
        Task<IEnumerable<Item>> GetAllAsync_Item(bool forceRefresh = false);

        Task<bool> AddAsync_Hero(Hero data);
        Task<bool> UpdateAsync_Hero(Hero data);
        Task<bool> DeleteAsync_Hero(Hero data);
        Task<Hero> GetAsync_Hero(string id);
        Task<IEnumerable<Hero>> GetAllAsync_Hero(bool forceRefresh = false);
        Task<IEnumerable<Hero>> GetAsync_HeroParty(bool forceRefresh = false);

        Task<bool> AddAsync_Monster(Monster data);
        Task<bool> UpdateAsync_Monster(Monster data);
        Task<bool> DeleteAsync_Monster(Monster data);
        Task<Monster> GetAsync_Monster(string id);
        Task<IEnumerable<Monster>> GetAllAsync_Monster(bool forceRefresh = false);
        Task<IEnumerable<Monster>> GetAsync_MonsterParty(int level);

        Task<bool> AddAsync_Score(Score data);
        Task<bool> UpdateAsync_Score(Score data);
        Task<bool> DeleteAsync_Score(Score data);
        Task<Score> GetAsync_Score(string id);
        Task<IEnumerable<Score>> GetAllAsync_Score(bool forceRefresh = false);

    }
}
