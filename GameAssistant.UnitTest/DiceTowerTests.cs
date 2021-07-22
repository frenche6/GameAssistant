using GameAssistant.Interfaces;
using GameAssistant.Models;
using GameAssistant.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameAssistant.UnitTest
{
    public class DiceTowerTests
    {
        

        [Fact]
        public void DiceTowerSetup_SetupSuccessfully()
        {
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);
            Assert.NotNull(diceTower.Dice);
            Assert.Empty(diceTower.Dice);
            Assert.NotNull(diceTower.RollHistories);
            Assert.Empty(diceTower.RollHistories);
        }

        [Fact]
        public void AddDie_AddsDieSuccessfully()
        {
            //var modifiedResults = new List<int>() { 3 };

            //var diceResolution = new DiceResolution<int>(modifiedResults, "3");
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            //diceResolverMock.Setup(x => x.ModifyDice(It.IsAny<List<BaseDie<int>>>())).Returns(diceResolution);

            var diceTower = new DiceTower<int>(diceResolverMock.Object);
            var die = new NumberDie(6);
            diceTower.AddDie(die);
            Assert.Single(diceTower.Dice);
        }

        [Fact]
        public void AddDice_AddsDiceSuccessfully()
        {
            var diceResolverMock = new Mock<IDiceResolver<int>>();

            var diceTower = new DiceTower<int>(diceResolverMock.Object);
            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();

            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            diceTower.AddDice(dice);
            Assert.Equal(numberOfDiceToAdd, dice.Count);
        }

        [Fact]
        public void RemoveDie_IndexGreaterThanCount_ThrowArgumentOutOfRangeException()
        {
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();
            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => diceTower.RemoveDie(dice.Count + 1));
        }

        [Fact]
        public void RemoveDie_RemovesDieSuccessfully()
        {
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();
            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            diceTower.Dice = dice;

            diceTower.RemoveDie(numberOfDiceToAdd - 1);
            Assert.Equal(numberOfDiceToAdd - 1, dice.Count);
        }

        [Fact]
        public void EmptyDiceTower_EmptiesDiceArray()
        {
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();
            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            diceTower.Dice = dice;

            diceTower.EmptyDiceTower();
            Assert.Empty(diceTower.Dice);
        }
    }
}