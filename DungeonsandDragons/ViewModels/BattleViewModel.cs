using System;
using System.Linq;

namespace DungeonsandDragons
{
    public class BattleViewModel: BaseViewModel
    {

        public Hero[] Heros = new Hero[5]; // Holds the 6 heros for battles
        public Monster[] Monsters = new Monster[5]; // Holds the monsters for battles



        public BattleViewModel()
        {
            Title = "Battle Page";
        }

        //Initialize the which party will attack first base on highest speed
        //Return true: batlte starts
        //Return false: battle has started
        public bool startBattle()
        {
            return true;   
        }


        //Determine which party will attack, and do the attack
        //Return 0: no party has die
        //Return -1: monster party dies
        public int fight(Hero[] heros, Monster[] monsters)
        {
            return 1;  
        }

        //Determine which party will attack, and do the attack
        //Return 0: no party has die
        //Return -1: monster party dies
        //Return 1: character party dies
        public int takeTurn()
        {
            return 1;
        }


    }
}
