using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
using System.Linq;
namespace DungeonsandDragons
{
    //base class for Battle
    public class Battle
    {
        public List<Hero> Heroes { set; get; } // Holds list of the 6 heroes
        public List<Monster> Monsters { set; get; } // Holds list of the 6 monsters
        public Queue<Item> DroppedItems { set; get; } // keeps a track of dropped items
<<<<<<< HEAD
        public int round { set; get; } //specifies number of rounds
        public int MonsterTurnNumber; //specifies monster turn
        public bool HeroesTurn; //specifies heroes turn
        public int HeroTurnNumber; //specifies heroes turn
=======
        public int round { set; get; }
        public int MonsterTurnNumber;
        public bool HeroesTurn;
        public int HeroTurnNumber;
        public Queue<Character> OrderQ { set; get; }

>>>>>>> b44e981... Update Battle

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
            this.OrderQ = new Queue<Character>();
        }

        // Checking if all the monsters are dead
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
        //Return 1: character party dies
        public Character takeTurn()
        {
            int curIndex;

            var current = OrderQ.Peek();
            if(current.myType == "Hero"){
                curIndex = Heroes.FindIndex(hero => hero.Id == current.Id);
                HeroesTurn = true;
            }else{
                curIndex = Monsters.FindIndex(monster => monster.Id == current.Id);
                HeroesTurn = false;
            }


            if(HeroesTurn)
            {
                Monster Defender = (Monster)whoDefenseNext();
                int exp = 0;
                exp = Defender.takeDamage(Heroes[curIndex].attack());
                Heroes[curIndex].gainExperience(exp);
                var index = Monsters.FindIndex(monster => monster.Id == Defender.Id);
                Monsters[index] = Defender;
                //HeroTurnNumber++;
                if(Defender.isAlive == false){
                    DroppedItems.Enqueue(Defender.SpecialItem);
                }
                OrderQ.Dequeue();
                OrderQ.Enqueue(new Character(Heroes[curIndex]));
            }
            else
            {
                Hero Defender = (Hero)whoDefenseNext();
                Defender.takeDamage(Monsters[curIndex].attack());
                var index = Heroes.FindIndex(hero => hero.Id == Defender.Id);
                Heroes[index] = Defender;
                //MonsterTurnNumber++;
                if (Defender.isAlive == false)
                {
                    foreach (Item item in Defender.Items)
                    {
                        var temp = new Item();
                        temp.Update(item);
                        DroppedItems.Enqueue(temp);
                    }

                }
                OrderQ.Dequeue();
                OrderQ.Enqueue(new Character(Monsters[curIndex]));


            }

            //HeroesTurn = !HeroesTurn;

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
            var temp = whoPlayNext();
            if(temp.myType =="Hero")
            {
                HeroesTurn = true;    
            }
            else
            {
                HeroesTurn = false;
            }
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

        //decides next hero/monster to attack
        public Character whoPlayNext()
        {
            //this.HeroTurnNumber = this.HeroTurnNumber % 6;
            //this.MonsterTurnNumber = this.MonsterTurnNumber % 6;
            //if(HeroesTurn)
            //{
            //    while(!this.Heroes[HeroTurnNumber].isAlive){
            //        HeroTurnNumber++;
            //        this.HeroTurnNumber = this.HeroTurnNumber % 6;
            //    }
            //    return new Hero(this.Heroes[HeroTurnNumber]);   
            //}
            //else
            //{
            //    while (!this.Monsters[MonsterTurnNumber].isAlive)
            //    {
            //        MonsterTurnNumber++;
            //        this.MonsterTurnNumber = this.MonsterTurnNumber % 6;
            //    }
            //    return new Monster(this.Monsters[MonsterTurnNumber]);    
            //}

            bool done = false;
            while (!done)
            {
                var temp = OrderQ.Peek();
                if (temp.myType == "Hero")
                {
                    var index = Heroes.FindIndex(hero => hero.Id == temp.Id);
                    if (!Heroes[index].isAlive)
                    {
                        OrderQ.Dequeue();
                    }
                    else
                    {
                        done = true;
                    }
                }
                else
                {
                    var index = Monsters.FindIndex(monster => monster.Id == temp.Id);
                    if (!Monsters[index].isAlive)
                    {
                        OrderQ.Dequeue();
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return OrderQ.Peek();
        }

        // nextRound function will assign new monster with new special Items in Monsters array
        public Character nextRound(List<Monster> monsters)
        {
<<<<<<< HEAD
=======
            if(round > 0){
                arrangeItems();
            }
>>>>>>> b44e981... Update Battle
            this.Monsters.Clear();
            foreach (Monster monster in monsters)
            {
                this.Monsters.Add(monster);
            }

            List<Character> temp = new List<Character>();
            foreach(Monster monster in monsters)
            {
                temp.Add(new Monster(monster));
            }
            foreach(Hero hero in Heroes)
            {
                temp.Add(new Hero(hero));   
            }

            List<Character> Sorted = temp.OrderByDescending(o => o.TotalSpeed).ToList();
            foreach (Character c in Sorted)
            {
                OrderQ.Enqueue(new Character(c));
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
                    index = -1;
                    for (int i = 0; i < Heroes.Count; i++)
                    {
                        if (Heroes[i].isAlive == true && Heroes[i].Items[(int)item.Location].Value < min)
                        {
                            min = Heroes[i].Items[(int)item.Location].Value;
                            index = i;
                        }
                    }
                    if (index == -1)
                    {
                        Heroes[index].Items[(int)item.Location] = item;
                    }
                }

            }
        }

    }
}
