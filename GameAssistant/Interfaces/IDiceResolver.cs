using System.Collections.Generic;
using GameAssistant.Models;

namespace GameAssistant.Interfaces
{
    public interface IDiceResolver<T>
    {
        /// <summary>
        /// Current: returns back list of dice passed in
        /// Future: Modifies a dice result set based on a set of rules
        /// </summary>
        /// <param name="dice">The dice to apply rules against</param>
        /// <returns>The modified list of dice</returns>
        DiceResolution<T> OrderDice(List<BaseDie<T>> dice);

        DiceResolution<T> ExplodeDice(List<BaseDie<T>> dice);
    }
}