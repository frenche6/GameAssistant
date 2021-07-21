using System.Collections.Generic;

namespace GameAssistant.Models
{
    public class DiceBag<T>
    {
        public List<BaseDie<T>> Dice = new List<BaseDie<T>>();
        public RollHistory<T> RollHistory = new RollHistory<T>();

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
            Dice.RemoveAt(index);
        }

        public void EmptyDiceBag()
        {
            Dice.Clear();
        }

        public List<T> RollBag()
        {
            var results = new List<T>();
            foreach (var die in Dice)
            {
                var dieResult = die.Roll();
                results.Add(dieResult);
                RollHistory.DiceRolled.Add(dieResult);
                RollHistory.ModifiedRolled.Add(dieResult);
            }

            return results;
        }
    }
}