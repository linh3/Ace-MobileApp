using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
using System.Linq;
namespace DungeonsandDragons
{
    public class Battle
    {
        public List<Hero> Heroes { set; get; } // Holds list of the 6 heroes
        public List<Monster> Monsters { set; get; } // Holds list of the 6 monsters
        public Queue<Item> DroppedItems { set; get; } // keeps a track of dropped items
        public int round { set; get; }
        public int MonsterTurnNumber;
        public bool HeroesTurn;
        public int HeroTurnNumber;


        public Battle()
        {
            round = 0;
            this.Heroes = new List<Hero>();
            this.Monsters = new List<Monster>();
            this.DroppedItems = new Queue<Item>();
            this.HeroesTurn = true;
            this.HeroTurnNumber = 0;
            this.MonsterTurnNumber = 0;
            for (int i = 0 ;i < 6; i++)
            {
                Heroes.Add(new Hero());
                Monsters.Add(new Monster());
            }

        }

        //Initialize the which party will attack first base on highest speed
        //Return true: batlte starts
        //Return false: battle has started
        //public bool startBattle()
        //{
            
        //    return true;
        //}


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
        //public int fight()
        //{
        //    return 1;
        //}


        //Determine which party will attack, and do the attack
        //Return 0: no party has die
        //Return -1: monster party dies
        //Return 1: character party dies
        public Character takeTurn()
        {
            if(HeroesTurn)
            {
                Monster Defender = (Monster)whoDefenseNext();
                int exp = 0;
                exp = Defender.takeDamage(Heroes[HeroTurnNumber].attack());
                Heroes[HeroTurnNumber].gainExperience(exp);
                var index = Monsters.FindIndex(monster => monster.Id == Defender.Id);
                Monsters[index] = Defender;
                HeroTurnNumber++;
                if(Defender.isAlive == false){
                    DroppedItems.Enqueue(Defender.SpecialItem);
                }
            }
            else
            {
                Hero Defender = (Hero)whoDefenseNext();
                Defender.takeDamage(Monsters[MonsterTurnNumber].attack());
                var index = Heroes.FindIndex(hero => hero.Id == Defender.Id);
                Heroes[index] = Defender;
                MonsterTurnNumber++;

            }

            HeroesTurn = !HeroesTurn;

            if(isAllHeoresDead() || isAllMonstersDead())
            {
                return null;    
            }

            return whoPlayNext();
        }

        //Helps the player pause the game in between
        //puts the game in sleep mode 
        //returns true if paused
        public bool pauseBattle()
        {
            return true;
        }

        public Character whoDefenseNext()
        {
            Character next = new Character();
            if(HeroesTurn)
            {
                
                next.Health = Int32.MaxValue;
                foreach(Monster each in Monsters)
                {
                    if(each.isAlive)
                    {
                        if(each.Health < next.Health)
                        {
                            next = each;   
                        }
                    }
                }
            }
            else
            {
                next.Health = Int32.MaxValue;
                foreach (Hero each in Heroes)
                {
                    if (each.isAlive)
                    {
                        if (each.Health < next.Health)
                        {
                            next = each;
                        }
                    }
                }
                
            }
            return next;
        }

        public Character whoPlayNext()
        {
            this.HeroTurnNumber = this.HeroTurnNumber % 6;
            this.MonsterTurnNumber = this.MonsterTurnNumber % 6;
            if(HeroesTurn)
            {
                while(!this.Heroes[HeroTurnNumber].isAlive){
                    HeroTurnNumber++;
                    this.HeroTurnNumber = this.HeroTurnNumber % 6;
                }
                return new Hero(this.Heroes[HeroTurnNumber]);   
            }
            else
            {
                while (!this.Monsters[MonsterTurnNumber].isAlive)
                {
                    MonsterTurnNumber++;
                    this.MonsterTurnNumber = this.MonsterTurnNumber % 6;
                }
                return new Monster(this.Monsters[MonsterTurnNumber]);    
            }
        }

        // nextRound function will assign new monster with new special Items in Monseters array
        public Character nextRound(List<Monster> monsters)
        {
            //if(round > 0){
            //    arrangeItems();
            //}
            this.Monsters.Clear();
            foreach (Monster monster in monsters)
            {
                this.Monsters.Add(monster);
            }

            round++;
            this.HeroesTurn = true;
            this.HeroTurnNumber = 0;
            this.MonsterTurnNumber = 0;
            return whoPlayNext();
        }

        //returns true if all heroes are dead
        public bool GameOver(Hero[] heroes)
        {
            return true;
        }

        public void arrangeItems()
        {
            while(DroppedItems.Count > 0)
            {
                Item item = DroppedItems.Dequeue();
                bool found = false;
                int min= Int32.MaxValue;
                int index = 0;
               
                while(!found && index < Heroes.Count){
                    if(Heroes[index % Heroes.Count].Items[(int)item.Location] == null && Heroes[index % Heroes.Count].isAlive == true){
                        Heroes[index % Heroes.Count].Items[(int)item.Location] = item;
                        Heroes[index % Heroes.Count].updateTotalAttributeValues();
                        found = true;
                    }
                    index++;
                }
                if(!found)
                {
                    for (int i = 0; i < Heroes.Count; i++){
                        if(Heroes[index % Heroes.Count].isAlive == true && Heroes[index % Heroes.Count].Items[(int)item.Location].Value < min){
                            min = Heroes[index % Heroes.Count].Items[(int)item.Location].Value;
                            index = i;
                        }
                    }
                    Heroes[index].Items[(int)item.Location] = item;
                }

            }
        }

    }
}
