using System.Collections.Generic;
using GameAssistant.Models;

namespace GameAssistant.Interfaces
{
    public interface IDiceTower<T>
    {
        /// <summary>
        /// Adds a single die to the dice tower
        /// </summary>
        /// <param name="die">The die to add</param>
        void AddDie(BaseDie<T> die);

        /// <summary>
        /// Adds a list of dice to the dice tower
        /// </summary>
        /// <param name="dice">The list of dice to add</param>
        void AddDice(List<BaseDie<T>> dice);

        /// <summary>
        /// Removes a single dice at the provided index
        /// </summary>
        /// <param name="index">The index to remove a die</param>
        void RemoveDie(int index);


        /// <summary>
        /// Empties the dice tower of all dice
        /// </summary>
        void EmptyDiceTower();


        /// <summary>
        /// Rolls the collection of dice in the bag.
        /// Creates a history item for the dice rolled.
        /// Returns list of modified dice results.
        /// </summary>
        /// <returns>List of modified dice results</returns>
        DiceResolution<T> Roll();
    }
}