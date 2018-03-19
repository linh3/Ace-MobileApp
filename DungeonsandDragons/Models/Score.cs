using System;
using SQLite;

using System.Collections.Generic;
using DungeonsandDragons.Models;
namespace DungeonsandDragons.Models
                            
{
    //base class for Score
    public class Score
    {
        //id is unique identifier
        [PrimaryKey]
        public string Id { get; set; }

        //score name
        public string Name { get; set; }

        //represents total score
        public int ScoreTotal { set; get; }

        //update score attributes
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
