using System;
namespace DungeonsandDragons
{
    // Represent the item location
    public enum ItemLocation
    {
        MaxItem = 7,
        Head = 0,
        Body = 1,
        Feet = 2,
        LeftHand = 3,
        RightHand = 4,
        LeftFinger = 5,
        RightFinger = 6,
    }

    // Represent the table of Attribute Chart
    public static class LevelAttributeChart
    {
        public static Attributes[] table = new Attributes[21]; 
        static LevelAttributeChart()
        {
            table[0].Speed = 0;
            table[0].Attack = 0;
            table[0].Defense = 0;
            table[1].Speed = 1;
            table[1].Attack = 1;
            table[1].Defense = 1;
            table[2].Speed = 1;
            table[2].Attack = 1;
            table[2].Defense = 2;
            table[3].Speed = 1;
            table[3].Attack = 2;
            table[3].Defense = 3;
            table[4].Speed = 1;
            table[4].Attack = 2;
            table[4].Defense = 3;
            table[5].Speed = 2;
            table[5].Attack = 2;
            table[5].Defense = 4;
            table[6].Speed = 2;
            table[6].Attack = 3;
            table[6].Defense = 4;
            table[7].Speed = 2;
            table[7].Attack = 3;
            table[7].Defense = 5;
            table[8].Speed = 2;
            table[8].Attack = 3;
            table[8].Defense = 5;
            table[9].Speed = 2;
            table[9].Attack = 3;
            table[9].Defense = 5;
            table[10].Speed = 3;
            table[10].Attack = 4;
            table[10].Defense = 6;
            table[11].Speed = 3;
            table[11].Attack = 4;
            table[11].Defense = 6;
            table[12].Speed = 3;
            table[12].Attack = 4;
            table[12].Defense = 6;
            table[13].Speed = 3;
            table[13].Attack = 4;
            table[13].Defense = 7;
            table[14].Speed = 3;
            table[14].Attack = 5;
            table[14].Defense = 7;
            table[15].Speed = 4;
            table[15].Attack = 5;
            table[15].Defense = 7;
            table[16].Speed = 4;
            table[16].Attack = 5;
            table[16].Defense = 8;
            table[17].Speed = 4;
            table[17].Attack = 5;
            table[17].Defense = 8;
            table[18].Speed = 4;
            table[18].Attack = 6;
            table[18].Defense = 8;
            table[19].Speed = 4;
            table[19].Attack = 7;
            table[19].Defense = 9;
            table[20].Speed = 5;
            table[20].Attack = 8;
            table[20].Defense = 10;
        }
    }

    public struct Attributes
    {
        public int Speed;
        public int Defense;
        public int Attack;
    }
}

