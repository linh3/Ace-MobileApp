using System;
using System.Data;
using System.Collections.Generic;
namespace DungeonsandDragons
{

    public class Character
    {
        public string Name { set; get; }
        //The name is used to display the character to the user 
        public string ImageLink { set; get; }
        //Use to display the image of this character to the user. 
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
        }


        // Generate the attack number from this character
        public int attack() => this.Strength;

        // Generate the defense number from this character
        public int defense() => this.Defense;

        // Calculate the health precentage for display purpose
        public float healthPercentage()
        {
            return (float)this.Health / (float)this.MaxHealth;
        }

        // Subtract the current health with the damage
        public void takeDamage(int damage)
        {
            this.Health -= damage;
        }

        // Check if the character is dead or not
        // return true when dead, false when alive
        public bool isDead()
        {
            if(this.Health <= 0){
                return true;
            }else{
                return false;
            }
        }

        // update the attribute Values with the AttributeChart with current level
        public void updateAttributeValues()
        {
            this.Strength = LevelAttributeChart.table[this.Level].Attack;
            this.Defense = LevelAttributeChart.table[this.Level].Defense;
            this.Speed = LevelAttributeChart.table[this.Level].Speed;
        }

    }
}
