using System;
namespace DungeonsandDragons
{
    public class Hero:Character
    {
        public Hero()
        {
            Name = "";
            ImageLink = "";
            Strength = 1;
            //TotalStrength = 1;
            Speed = 1;
            MaxHealth = 10;
            Health = 10;
            Level = 1;
            Experience = 0;
            Defense = 1;
            Items = null;
            this.Items = new int[Global.MAXITEM];
        }

        public void gainExperience(int experience)
        {
            this.Experience += experience;
        }

        public bool LevelUp()
        {
            if (this.Level == 1 && this.Experience >= 300)
            {
                this.Level++;
                this.Defense++;
                return true;
            }
            else if (this.Level == 2 && this.Experience >= 900)
            {
                this.Level++;
                this.Strength++;
                this.Defense++;
                return true;

            }
            else if (this.Level == 3 && this.Experience >= 2700)
            {
                this.Level++;
                return true;
            }
            else if (this.Level == 4 && this.Experience >= 6500)
            {
                this.Level++;
                this.Defense++;
                this.Speed++;
                return true;
            }
            else if (this.Level == 5 && this.Experience >= 14000)
            {
                this.Level++;
                this.Strength++;
                return true;
            }
            else if (this.Level == 6 && this.Experience >= 23000)
            {
                this.Level++;
                this.Defense++;
                return true;
            }
            else if (this.Level == 7 && this.Experience >= 34000)
            {
                this.Level++;
                return true;
            }
            else if (this.Level == 8 && this.Experience >= 48000)
            {
                this.Level++;
                return true;
            }
            else if (this.Level == 9 && this.Experience >= 64000)
            {
                this.Level++;
                this.Strength++;
                this.Defense++;
                this.Speed++;
                return true;
            }
            else if (this.Level == 10 && this.Experience >= 85000)
            {
                this.Level++;
                return true;
            }
            else if (this.Level == 11 && this.Experience >= 100000)
            {
                this.Level++;
                return true;
            }
            else if (this.Level == 12 && this.Experience >= 120000)
            {
                this.Level++;
                this.Defense++;
                return true;
            }
            else if (this.Level == 13 && this.Experience >= 140000)
            {
                this.Level++;
                this.Strength++;
                return true;
            }
            else if (this.Level == 14 && this.Experience >= 165000)
            {
                this.Level++;
                this.Speed++;
                return true;
            }
            else if (this.Level == 15 && this.Experience >= 195000)
            {
                this.Level++;
                this.Defense++;
                return true;
            }
            else if (this.Level == 16 && this.Experience >= 225000)
            {
                this.Level++;
                return true;
            }
            else if (this.Level == 17 && this.Experience >= 265000)
            {
                this.Level++;
                this.Strength++;
                return true;
            }
            else if (this.Level == 18 && this.Experience >= 305000)
            {
                this.Level++;
                this.Strength++;
                this.Defense++;
                return true;
            }
            else if (this.Level == 19 && this.Experience >= 355000)
            {
                this.Level++;
                this.Strength++;
                this.Defense++;
                this.Speed++;
                return true;
            }
            else{
                return false;   
            }
        }
        public bool useItem(int item, int location)
        {
            if(location < 0 || location >= Global.MAXITEM || this.Items[location]!=0 /* location has been used*/){
                return false;
            }else{
                Items[location] = item;
                //also need to update the hero attributes (strength, defense...) before return
                return true;
            }
        }

        public int dropItem(int location){
            return this.Items[location];
        }

    }
}
