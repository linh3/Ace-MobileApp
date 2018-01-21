using System;
using System.Collections.Generic;
namespace DungeonsandDragons
{     
    public class Character
    {
        protected string Name;
        protected string ImageLink;
        protected int Strength;
       // protected int TotalStrength;
        protected int Speed;
        protected int MaxHealth;
        protected int Health;
        protected int Level;
        protected int Experience;
        protected int Defense;
        protected int [] Items; // Instead of having a list of int, we will have an list of item

        public Character()
        {
            Name = "";
            ImageLink = "";
            Strength = 0;
            //TotalStrength = 0;
            Speed = 0;
            MaxHealth = 0;
            Health = 0;
            Level = 0;
            Experience = 0;
            Defense = 0;
            Items = null;
        }

        public void setName(string name) => this.Name = name;

        public string getName() => this.Name;

        public void setImageLink(string link) => this.ImageLink = link;

        public string getImageLink() => this.ImageLink;

        public void setStrength(int strength) => this.Strength = strength;

        public int getStrength() => this.Strength;

        public void setSpeed(int speed) => this.Speed = speed;

        public int getSpeed() => this.Speed;

        public void setMaxHealth(int maxhealth) => this.MaxHealth = maxhealth;

        public int getMaxHealth() => this.MaxHealth;

        public void setHealth(int health) => this.Health = health;

        public int getHealth() => this.Health;

        public void setLevel(int level) => this.Level = level;

        public int getLevel() => this.Level;

        public void setExperience(int experience) => this.Experience = experience;

        public int getExperience() => this.Experience;

        public void setDefense(int defense) => this.Defense = defense;

        public int getDefense() => this.Defense;

        public int Attack() => this.Strength;

        public void Takedamage(int damage)
        {
            this.Health -= damage;
        }

        public bool checkDead()
        {
            if(this.Health <= 0){
                return true;
            }else{
                return false;
            }
        }

    }
}
