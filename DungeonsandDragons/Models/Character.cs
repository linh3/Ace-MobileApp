using System;
using System.Collections.Generic;
namespace DungeonsandDragons
{     
    public class Character
    {
        protected string Name;
        //The name is used to display the character to the user 
        protected string ImageLink;
        //Use to display the image of this character to the user. 
        protected int Strength;
        // Represents the attack ability of current character. 
       // protected int TotalStrength;
        protected int Speed;
        // Represents how fast the character plays 
        protected int MaxHealth;
        // Represents the maximum heath 

        protected int Health;
        // Represents the current health 

        protected int Level;
        // Represents the current level 
        protected int Experience;
        // Represents the current experience points 
        protected int Defense;
        // Represents the character’s ability to defend itself from attack

        protected int [] Items; 
        // Instead of having a list of int, we will have an list of item
        // contains all items for the character 
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
        // Generate the attack number from this hero


        public void Takedamage(int damage)
        {
            this.Health -= damage;
        }
        // Subtract the current health with the damage


        public bool checkDead()
        {
            if(this.Health <= 0){
                return true;
            }else{
                return false;
            }
        }
        // Return true if the Role is dead, else return false


    }
}
