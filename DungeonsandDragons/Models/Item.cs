using System;

namespace DungeonsandDragons
{
    public class Item
    {
        public string Id { get; set; } // for removing error in MockDataStore
        public string Text { get; set; }// for removing error in MockDataStore
        public String Description { get; set;}// for removing error in MockDataStore

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
        }
    }

}
