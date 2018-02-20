using System;
using DungeonsandDragons.Models;

namespace DungeonsandDragons.ViewModels
{
    public class MonsterDetailViewModel : BaseViewModel
    {
        public Monster Monster { get; set; }
        public MonsterDetailViewModel(Monster monster = null)
        {
            Title = monster?.Name;
            Monster = monster;
        }
    }
}
