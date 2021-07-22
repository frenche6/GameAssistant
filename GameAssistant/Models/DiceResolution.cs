using System.Collections.Generic;

namespace GameAssistant.Models
{
    /// <summary>
    /// A result set of dice after they have been modified
    /// </summary>
    /// <typeparam name="T">The collection of dice to modify</typeparam>
    public record DiceResolution<T>(List<T> ModifiedDice, string ResultResolution);
}