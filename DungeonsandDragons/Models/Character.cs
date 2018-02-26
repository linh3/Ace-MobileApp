using System;
using System.Data;
using System.Collections.Generic;
using SQLite;
namespace DungeonsandDragons.Models
{

    public class Character
    {
        [PrimaryKey]
        public string Id { set; get; }
        public string Name { set; get; }
        //The name is used to display the character to the user 
        public string ImageLink { set; get; }
        //Use to display the image of this character to the user. 
        public int TotalStength { set; get; }

        public int TotalSpeed { set; get; }

        public int TotalDefense { set; get; }

        public int Strength{set; get;}
        // Represents the attack ability of current character. 
       // public int TotalStrength;
        public int Speed { set; get; }
        // Represents how fast the character plays 
        public int MaxHealth { set; get; }
        // Represents the maximum heath 

        public int Health { set; get; }
        // Represents the current health 

        public int Level { set; get; }
        // Represents the current level 
        public int Experience { set; get; }
        // Represents the current experience points 
        public int Defense { set; get; }
        // Represents the character’s ability to defend itself from attack

        public bool isAlive { set; get; }
 
        public Character()
        {
            Name = "";
            ImageLink = "";
            Strength = 0;
            Speed = 0;
            MaxHealth = 0;
            Health = 0;
            Level = 0;
            Experience = 0;
            Defense = 0;
            isAlive = true;
            TotalSpeed = 0;
            TotalDefense = 0;
            TotalStength = 0;
        }


        // Generate the attack number from this character
        public int attack() => this.TotalStength;

        // Generate the defense number from this character
        public int defense() => this.Defense;

        // Calculate the health percentage for display purpose
        public float healthPercentage()
        {
            return (float)this.Health / (float)this.MaxHealth;
        }





        // update the attribute Values with the AttributeChart for current level
        virtual public void updateCharacterAttributeValues()
        {
            this.Strength = LevelAttributeChart.table[this.Level].Attack;
            this.Defense = LevelAttributeChart.table[this.Level].Defense;
            this.Speed = LevelAttributeChart.table[this.Level].Speed;
            int newMaxHealth = 5 + this.Level * 5;
            this.Health = newMaxHealth - (this.MaxHealth - this.Health);
            this.MaxHealth = newMaxHealth;
            if(this.Experience < LevelAttributeChart.table[this.Level-1].Experience)
            {
                this.Experience = LevelAttributeChart.table[this.Level - 1].Experience;
            }
        }


    }
}
