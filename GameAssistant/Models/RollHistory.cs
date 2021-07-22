using System;
using System.Collections.Generic;

namespace GameAssistant.Models
{
    public class RollHistory<T>
    {
        public List<BaseDie<T>> DiceRolled { get; set; } = new List<BaseDie<T>>();
        public List<T> OriginalRolled { get; set; } = new List<T>();
        public DiceResolution<T> ModifiedRolled { get; set; }
        public DateTime WhenRolled { get; set; } = DateTime.Now;
    }
}