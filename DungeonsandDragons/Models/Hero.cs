using System;
namespace DungeonsandDragons.Models
{
    public class Hero:Character
    {
        // contains all items for the character
        public Item[] Items { set; get; } 

        public Hero()
        {
            Name = "";
            ImageLink = "";
            Level = 0;
            this.Items = new Item[(int)ItemLocation.MaxItemLocation];
            updateLevel();
            updateCharacterAttributeValues();
            updateTotalAttributeValues();
        }

        public Hero(Hero rhs)
        {
            Id = rhs.Id;
            Name = rhs.Name;
            ImageLink = rhs.ImageLink;
            Level = rhs.Level;
            this.Items = new Item[(int)ItemLocation.MaxItemLocation];
            updateLevel();
            updateCharacterAttributeValues();
            updateTotalAttributeValues();
        }

        // Add experience points to the current hero
        // check if the hero can level up or not
        public void gainExperience(int experience)
        {
            this.Experience += experience;
            updateLevel();
        }

        public void updateTotalAttributeValues()
        {
            this.TotalSpeed = this.Speed;
            this.TotalDefense = this.Defense;
            this.TotalStength = this.Strength;
            foreach(Item item in Items)
            {
                if(item != null){
                    this.TotalSpeed += item.Speed;
                    this.TotalDefense += item.Defense;
                    this.TotalStength += item.Strength;
                }
            }

        }

        // Level up the hero if eligible
        // update all character attributes with new level.
        public void updateLevel()
        {
            bool finish = false;
            while(!finish)
            {
                if (LevelAttributeChart.table[this.Level].Experience <= this.Experience)
                {
                    this.Level++;
                }
                else
                {
                    finish = true;
                }
            }
            updateCharacterAttributeValues();
            updateTotalAttributeValues();
        }


        // return false if bad location or location has been used
        // else equip the item and return true
        // will also update the attribute value when Item class is created
        public bool pickItem(Item item, int location)
        {
            if(location < 0 || location >= (int)ItemLocation.MaxItemLocation || this.Items[location]!=null /* location has been used*/){
                return false;
            }else{
                Items[location] = item;
                updateTotalAttributeValues();
                return true;
            }
        }

        // drop the item in specific location to the ground
        public Item dropItem(int location){
            Item temp = this.Items[location];
            this.Items[location] = null;
            updateTotalAttributeValues();
            return temp;
        }

        // drop all item to the ground
        // will also update the attribute value when Item class is created
        public Item[] dropAllItem()
        {
            Item[] temp = (Item[])this.Items.Clone();
            for (int i = 0; i < (int)ItemLocation.MaxItemLocation; i++){
                this.Items[i] = null;
            }
            updateTotalAttributeValues();
            return temp;
        }

        // restore health to 100%
        public void restoreHealth()
        {
            this.Health = this.MaxHealth;   
        }

        public void Update(Hero data)
        {
            Name = data.Name;
            ImageLink = data.ImageLink;
        }

        // Subtract the current health with the damage
        public void takeDamage(int damage)
        {
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.isAlive = false;
            }
        }

    }
}
