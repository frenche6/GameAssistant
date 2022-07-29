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
        public List<DiceModifier> Modifiers = new List<DiceModifier>();

        //Services
        private readonly IDiceResolver<T> _diceResolver;

        public DiceTower(IDiceResolver<T> diceModifierService)
        {
            _diceResolver = diceModifierService;
        }
        
        /// <summary>
        /// Adds a single die to the list of dice
        /// </summary>
        /// <param name="die"></param>
        public void AddDie(BaseDie<T> die)
        {
            Dice.Add(die);
        }
        
        /// <summary>
        /// Adds a list of dice to the list of dice
        /// </summary>
        /// <param name="dice"></param>
        public void AddDice(List<BaseDie<T>> dice)
        {
            Dice.AddRange(dice);
        }

        /// <summary>
        /// Removes a die at the provided index
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveDie(int index)
        {
            if (index >= Dice.Count)
                throw new ArgumentOutOfRangeException();

            Dice.RemoveAt(index);
        }

        /// <summary>
        /// Removes all dice from the list of dice
        /// </summary>
        public void EmptyDiceTower()
        {
            Dice.Clear();
            Modifiers.Clear();
        }
        
        public DiceResolution<T> Roll()
        {
            var results = Dice.Select(die => die.Roll()).ToList();

            foreach (var modifier in Modifiers)
            {
                
            }
            var modifiedResults = _diceResolver.OrderDice(Dice);

            //Create history item
            var historyItem = new RollHistory<T>
            {
                DiceRolled = Dice, //Add dice rolled to history
                OriginalRolled = results, //Add original rolls to history
                ModifiedRolled = modifiedResults, //Go run modify rules on original rolls
                Modifiers = Modifiers
            };

            //Store modified rolls in history
            RollHistories.Add(historyItem);

            //Empty the bag of dice after the roll is complete
            EmptyDiceTower();

            return modifiedResults;
        }

        private void determineModifier(DiceModifier modifier)
        {
            switch (modifier)
            {
                case DiceModifier.Explode: 
            }
        }
    }
}