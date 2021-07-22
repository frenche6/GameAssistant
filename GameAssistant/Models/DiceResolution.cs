using System.Collections.Generic;

namespace GameAssistant.Models
{
    public record DiceResolution<T>(List<T> ModifiedDice, string ResultResolution);
}