using System;
namespace DungeonsandDragons
{
    public class Battle
    {
        public Hero[] Heroes = new Hero[5]; // Holds list of the 6 heroes
        public Monster[] Monsters = new Monster[5]; // Holds list of the 6 monsters
        public Item[] Items = new Item[10]; // Holds list of items
        public Item[] DroppedItems = new Item[10]; // keeps a track of dropped items
        public Monster[] deadMonsters = new Monster[5]; // keeps a track of dead monsters

        public Battle()
        {
            this.Heroes = new Hero[5];
            this.Monsters = new Monster[5];
            this.Items = new Item[10];
            this.DroppedItems = null;
            this.deadMonsters = null;
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
        public int fight(Hero[] heroes, Monster[] monsters)
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

        //Helps the player pause the game in between
        //puts the game in sleep mode 
        //returns true if paused
        public bool pauseBattle()
        {
            return true;
        }

        //returns true if all monsters are dead and battle reaches next level
        public bool nextLevel(Monster[] deadMonsters)
        {
            return true;
        }

        //returns true if all heroes are dead
        public bool GameOver(Hero[] heroes)
        {
            return true;
        }
    }
}
