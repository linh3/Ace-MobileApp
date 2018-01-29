using System;
namespace DungeonsandDragons
{
    public class Monster:Character
    {

        public Item SpecialItem;

        public Monster()
        {
            Name = "";
            ImageLink = "";
            Strength = 1;
            Speed = 1;
            MaxHealth = 10;
            Health = 10;
            Level = 0;
            Experience = 0;
            Defense = 1;
            SpecialItem = null;
        }
        // set the level for monster
        // update the attribute values base on the level
        public void setLevelTo(int level)
        {
            this.Level = level;
            updateAttributeValues();
        }

        // return false if bad location or location has been used
        // else equip the item and return true
        public void setSpcialItem(Item item)
        {
            this.SpecialItem = item;   
        }

        // drop the item in specific location.
        public Item dropSpecialItem()
        {
            return this.SpecialItem;
        }

    }
}
