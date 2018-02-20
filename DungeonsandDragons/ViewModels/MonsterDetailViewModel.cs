using System;
using DungeonsandDragons.Models;

namespace DungeonsandDragons.ViewModels
{
    public class HeroDetailViewModel : BaseViewModel
    {
        public Hero Hero { get; set; }
        public HeroDetailViewModel(Hero hero = null)
        {
            Title = hero?.Name;
            Hero = hero;
        }
    }
}
