using System;
namespace DungeonsandDragons
{
    public class Hero:Character
    {
        // contains all items for the character
        public Item[] Items { set; get; } 

        public Hero()
        {
            Name = "";
            ImageLink = "";
            Strength = 1;
            //TotalStrength = 1;
            Speed = 1;
            MaxHealth = 10;
            Health = 10;
            Level = 0;
            Experience = 0;
            Defense = 1;
            Items = null;
            this.Items = new Item[(int)ItemLocation.MaxItem];
        }

        // Add experience points to the current hero
        // check if the hero can level up or not
        public void gainExperience(int experience)
        {
            this.Experience += experience;
            updateLevel();
        }

        // Level up the hero if eligible
        // update all character attributes with new level.
        public void updateLevel()
        {
            int tempLevel = 0;
            if (this.Experience >= 355000)
            {
                tempLevel = 20;

            }
            else if (this.Experience >= 305000)
            {
                tempLevel = 19;
            }
            else if (this.Experience >= 265000)
            {
                tempLevel = 18;
            }
            else if (this.Experience >= 225000)
            {
                tempLevel = 17;
            }
            else if (this.Experience >= 195000)
            {
                tempLevel = 16;
            }
            else if (this.Experience >= 165000)
            {
                tempLevel = 15;
            }
            else if (this.Experience >= 140000)
            {
                tempLevel = 14;
            }
            else if (this.Experience >= 120000)
            {
                tempLevel = 13;
            }
            else if (this.Experience >= 100000)
            {
                tempLevel = 12;
            }
            else if (this.Experience >= 85000)
            {
                tempLevel = 11;
            }
            else if (this.Experience >= 64000)
            {
                tempLevel = 10;
            }
            else if (this.Experience >= 48000)
            {
                tempLevel = 9;
            }
            else if (this.Experience >= 34000)
            {
                tempLevel = 8;
            }
            else if (this.Experience >= 23000)
            {
                tempLevel = 7;
            }
            else if (this.Experience >= 14000)
            {
                tempLevel = 6;
            }
            else if (this.Experience >= 6500)
            {
                tempLevel = 5;
            }
            else if (this.Experience >= 2700)
            {
                tempLevel = 4;
            }
            else if (this.Experience >= 900)
            {
                tempLevel = 3;
            }
            else if (this.Experience >= 300)
            {
                tempLevel = 2;

            }else{
                tempLevel = 1;
            }
            if(tempLevel != this.Level){
                this.Level = tempLevel;
                updateAttributeValues();
            }
        }


        // return false if bad location or location has been used
        // else equip the item and return true
        public bool pickItem(Item item, int location)
        {
            if(location < 0 || location >= (int)ItemLocation.MaxItem || this.Items[location]!=null /* location has been used*/){
                return false;
            }else{
                Items[location] = item;
                //also need to update the hero attributes (strength, defense...) before return
                return true;
            }
        }

        // drop the item in specific location to the ground
        public Item dropItem(int location){
            Item temp = this.Items[location];
            this.Items[location] = null;
            return temp;
        }

        // drop all item to the ground
        public Item[] dropAllItem()
        {
            Item[] temp = (Item[])this.Items.Clone();
            for (int i = 0; i < (int)ItemLocation.MaxItem; i++){
                this.Items[i] = null;
            }
            return temp;
        }

        // restore health to 100%
        public void restoreHealth()
        {
            this.Health = this.MaxHealth;   
        }
    }
}
