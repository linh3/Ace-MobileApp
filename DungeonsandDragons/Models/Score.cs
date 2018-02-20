using System;
using System.Collections.Generic;
using DungeonsandDragons.Models;
namespace DungeonsandDragons.Models
{
    public class Score
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int ScoreTotal { set; get; }

        public void Update(Score newData)
        {
            if (newData == null)
            {
                return;
            }

            // Update all the fields in the Data, except for the Id
            Name = newData.Name;
            ScoreTotal = newData.ScoreTotal;
        }
    }
}
