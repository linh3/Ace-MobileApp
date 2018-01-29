using System;
namespace DungeonsandDragons
{
    public class Monster:Character
    {
        // contain the special item for monster to drop
        public Item SpecialItem { set; get; }

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

        // set the item to monster for special drop
        // will also update the attribute value when Item class is created
        public void setSpcialItem(Item item)
        {
            this.SpecialItem = item;   
        }

        // drop the special item from monster.
        // will also update the attribute value when Item class is created
        public Item dropSpecialItem()
        {
            return this.SpecialItem;
        }

    }
}
