using System;
using SQLite;

namespace DungeonsandDragons.Models
{
    public class Item
    {
        [PrimaryKey]
        public string Id { get; set; } // for removing error in MockDataStore

        public string Description { get; set; }
        //The name is used to display the item to the user
        public string Name { get; set; }
        //The ImageLink is used to display the item image to the user
        public string ImageLink { get; set; }
        // The Location of an item is used to indicate the item's location. i.e. head, left finger etc.
        public int Location { get; set; }
        // The strength of an item is used to enhance the strength of the character holding the item
        public int Strength { get; set; }
        // The Defense of an item is used to enhance the defense of the character holding the item
        public int Defense { get; set; }
        // The Speed of an item is used to enhance the speed of the character holding the item
        public int Speed { get; set; }

        public Item()
        {
            Name = "";
            ImageLink = "";
            Location = 0;
            Strength = 0;
            Defense = 0;
            Speed = 0;
            Description = "";
        }

        public void Update(Item newItem)
        {
            if (newItem == null)
            {
                return;
            }

            this.Name = newItem.Name;
            this.Description = newItem.Description;
            this.ImageLink = newItem.ImageLink;
            this.Strength = newItem.Strength;
            this.Defense = newItem.Defense;
            this.Speed = newItem.Speed;


            return;
        }
    }

}
