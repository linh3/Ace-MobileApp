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

        public Monster(Monster rhs)
        {
            Id = rhs.Id;
            Name = rhs.Name;
            ImageLink = rhs.ImageLink;
            Strength = rhs.Strength;
            Speed = rhs.Speed;
            MaxHealth = rhs.MaxHealth;
            Health = rhs.Health;
            Level = rhs.Level;
            Experience = rhs.Experience;
            Defense = rhs.Defense;
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

        override public void updateCharacterAttributeValues()
        {
            this.Strength = LevelAttributeChart.table[this.Level].Attack;
            this.Defense = LevelAttributeChart.table[this.Level].Defense;
            this.Speed = LevelAttributeChart.table[this.Level].Speed;
            int newMaxHealth = 5 + this.Level * 5;
            this.Health = newMaxHealth - (this.MaxHealth - this.Health);
            this.MaxHealth = newMaxHealth;
            this.Experience = LevelAttributeChart.table[this.Level].Experience;
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

        // Subtract the current health with the damage
        public int takeDamage(int damage)
        {

            int exp = (int)(((float)damage / (float)MaxHealth) * Experience);
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.isAlive = false;
            }
            return exp;
        }
        public void Update(Monster data)
        {
            Name = data.Name;
            ImageLink = data.ImageLink;
        }

    }
}
