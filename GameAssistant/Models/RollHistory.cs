using System;
using System.Collections.Generic;

namespace GameAssistant.Models
{
    public class RollHistory<T>
    {
        public List<T> DiceRolled { get; set; } = new List<T>();
        public List<T> ModifiedRolled { get; set; } = new List<T>();
    }
}