using System;
using System.Collections.Generic;

namespace GameAssistant.Models
{
    public class RollHistory<T>
    {
        /// <summary>
        /// The set of dice that are rolled
        /// </summary>
        public List<BaseDie<T>> DiceRolled { get; set; } = new List<BaseDie<T>>();

        /// <summary>
        /// The original values rolled, before being modified
        /// </summary>
        public List<T> OriginalRolled { get; set; } = new List<T>();

        /// <summary>
        /// The modified values of values rolled
        /// </summary>
        public DiceResolution<T> ModifiedRolled { get; set; }

        /// <summary>
        /// The modifiers applied to the dice
        /// </summary>
        public List<DiceModifier> Modifiers { get; set; } = new List<DiceModifier>();

        /// <summary>
        /// When the dice were rolled
        /// </summary>
        public DateTime WhenRolled { get; set; } = DateTime.Now;
    }
}