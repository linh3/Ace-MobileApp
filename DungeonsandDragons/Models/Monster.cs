using System;
namespace DungeonsandDragons
{
    public class Monster:Character
    {
        public Monster()
        {
            Name = "";
            ImageLink = "";
            Strength = 1;
            Speed = 1;
            MaxHealth = 10;
            Health = 10;
            Level = 1;
            Experience = 0;
            Defense = 1;
            Items = null;
            this.Items = new int[Global.MAXITEM];
        }

        // Add experience points to the current monster
        public void gainExperience(int experience)
        {
            this.Experience += experience;
        }

        // Instead of having int as item, we will have an item as item
        // return false if bad location or location has been used
        // else equip the item and return true
        public bool useItem(int item, int location)
        {
            if (location < 0 || location >= Global.MAXITEM || this.Items[location] != 0 /* location has been used*/)
            {
                return false;
            }
            else
            {
                Items[location] = item;
                //also need to update the hero attributes (strength, defense...) before return
                return true;
            }
        }

        // drop the item in specific location.
        // Instead of return int, we will return an item
        public int dropItem(int location)
        {
            return this.Items[location];
        }
    }
}
