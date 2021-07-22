using System.Collections.Generic;
using GameAssistant.Models;

namespace GameAssistant.Interfaces
{
    public interface IDiceResolver<T>
    {
        DiceResolution<T> ModifyDice(List<BaseDie<T>> dice);
    }
}