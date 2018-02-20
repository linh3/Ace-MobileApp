using System;
using DungeonsandDragons.Models;

namespace DungeonsandDragons.ViewModels
{
    public class ScoreDetailViewModel : BaseViewModel
    {
        public Score Score { get; set; }
        public ScoreDetailViewModel(Score score = null)
        {
            Title = score?.Name;
            Score = score;
        }
    }
}
