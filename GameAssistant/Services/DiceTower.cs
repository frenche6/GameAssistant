using System;
using System.Collections.Generic;
using System.Linq;
using GameAssistant.Interfaces;
using GameAssistant.Models;

namespace GameAssistant.Services
{
    public class DiceTower<T> : IDiceTower<T>
    {
        public List<BaseDie<T>> Dice = new List<BaseDie<T>>();
        public List<RollHistory<T>> RollHistories = new List<RollHistory<T>>();

        //Services
        private readonly IDiceResolver<T> _diceResolver;

        public DiceTower(IDiceResolver<T> diceModifierService)
        {
            _diceResolver = diceModifierService;
        }
        
        public void AddDie(BaseDie<T> die)
        {
            Dice.Add(die);
        }
        
        public void AddDice(List<BaseDie<T>> dice)
        {
            Dice.AddRange(dice);
        }

        public void RemoveDie(int index)
        {
            if (index >= Dice.Count)
                throw new ArgumentOutOfRangeException();

            Dice.RemoveAt(index);
        }
        public void EmptyDiceTower()
        {
            Dice.Clear();
        }
        
        public DiceResolution<T> Roll()
        {
            var results = Dice.Select(die => die.Roll()).ToList();
            var modifiedResults = _diceResolver.ModifyDice(Dice);

            //Create history item
            var historyItem = new RollHistory<T>
            {
                DiceRolled = Dice, //Add dice rolled to history
                OriginalRolled = results, //Add original rolls to history
                ModifiedRolled = modifiedResults //Go run modify rules on original rolls
            };

            //Store modified rolls in history
            RollHistories.Add(historyItem);

            //Empty the bag of dice after the roll is complete
            EmptyDiceTower();

            return modifiedResults;
        }
    }
}