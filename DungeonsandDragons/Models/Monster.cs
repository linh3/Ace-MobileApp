using System;
namespace DungeonsandDragons.Models
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
            updateCharacterAttributeValues();
            updateTotalAttributeValues();
        }
        // set the level for monster
        // update the attribute values base on the level
        public void setLevelTo(int level)
        {
            this.Level = level;
            updateCharacterAttributeValues();
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

        public void updateTotalAttributeValues()
        {
            this.TotalSpeed = this.Speed;
            this.TotalDefense = this.Defense;
            this.TotalStength = this.Strength;
            if (SpecialItem != null)
            {
                this.TotalSpeed += SpecialItem.Speed;
                this.TotalDefense += SpecialItem.Defense;
                this.TotalStength += SpecialItem.Strength;
            }
        

        }

        public void Update(Monster data)
        {
            Name = data.Name;
            ImageLink = data.ImageLink;
        }

    }
}
