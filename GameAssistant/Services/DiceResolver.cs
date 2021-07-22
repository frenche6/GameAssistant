using System.Collections.Generic;
using System.Linq;
using GameAssistant.Interfaces;
using GameAssistant.Models;

namespace GameAssistant.Services
{
    public class DiceResolver<T> : IDiceResolver<T>
    {
        public DiceResolution<T> ModifyDice(List<BaseDie<T>> dice)
        {
            var results = dice.Select(x => x.FaceValue).OrderByDescending(x => x.ToString()).ToList();
            return new(results, string.Join(',', results));
        }
    }
}