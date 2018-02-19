using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
namespace DungeonsandDragons
{
    public class Battle
    {
        public Hero[] Heroes { set; get; } // Holds list of the 6 heroes
        public Monster[] Monsters { set; get; } // Holds list of the 6 monsters
        public List<Item> AllItems { set; get; } // Holds list of items
        public List<Item> DroppedItems { set; get; } // keeps a track of dropped items
        public int round { set; get; }

        public Battle()
        {
            round = 0;
            this.Heroes = new Hero[5];
            this.Monsters = new Monster[5];
            this.DroppedItems = new List<Item>();
            this.AllItems = new List<Item>();

        }

        //Initialize the which party will attack first base on highest speed
        //Return true: batlte starts
        //Return false: battle has started
        public bool startBattle()
        {
            return true;
        }


        // Checking if all the moonsters are dead
        // return true if all the monsters are dead
        // return false if not
        public bool isAllMonstersDead()
        {
            bool AllDead = true;
            foreach (Monster monster in Monsters)
            {
                if (monster.isAlive)
                {
                    AllDead = false;
                }
            }
            return AllDead;
        }

        // Checking if all the heroes are dead
        // return true if all the heroes are dead
        // return fasle if not
        public bool isAllHeoresDead()
        {
            bool AllDead = true;
            foreach (Hero hero in Heroes)
            {
                if (hero.isAlive)
                {
                    AllDead = false;
                }
            }
            return AllDead;
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

        // nextRound function will assign new monster with new special Items in Monseters array
        public void nextRound()
        {
            round++;
        }

        //returns true if all heroes are dead
        public bool GameOver(Hero[] heroes)
        {
            return true;
        }
    }
}
