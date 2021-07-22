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
            //Arrange
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            //Assert
            Assert.NotNull(diceTower.Dice);
            Assert.Empty(diceTower.Dice);
            Assert.NotNull(diceTower.RollHistories);
            Assert.Empty(diceTower.RollHistories);
        }

        [Fact]
        public void AddDie_AddsDieSuccessfully()
        {
            //Arrange
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            //Act
            var die = new NumberDie(6);
            diceTower.AddDie(die);

            //Assert
            Assert.Single(diceTower.Dice);
        }

        [Fact]
        public void AddDice_AddsDiceSuccessfully()
        {
            //Arrange
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            //Act
            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();

            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            diceTower.AddDice(dice);

            //Assert
            Assert.Equal(numberOfDiceToAdd, dice.Count);
        }

        [Fact]
        public void RemoveDie_IndexGreaterThanCount_ThrowArgumentOutOfRangeException()
        {
            //Arrange
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            //Act
            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();
            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => diceTower.RemoveDie(dice.Count + 1));
        }

        [Fact]
        public void RemoveDie_RemovesDieSuccessfully()
        {
            //Arrange
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            //Act
            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();
            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            diceTower.Dice = dice;
            diceTower.RemoveDie(numberOfDiceToAdd - 1);

            //Assert
            Assert.Equal(numberOfDiceToAdd - 1, dice.Count);
        }

        [Fact]
        public void EmptyDiceTower_EmptiesDiceArray()
        {
            //Arrange
            var diceResolverMock = new Mock<IDiceResolver<int>>();
            var diceTower = new DiceTower<int>(diceResolverMock.Object);

            //Act
            var numberOfDiceToAdd = 6;
            var dice = new List<BaseDie<int>>();
            for (var i = 0; i < numberOfDiceToAdd; i++)
            {
                dice.Add(new NumberDie(6));
            }

            diceTower.Dice = dice;
            diceTower.EmptyDiceTower();

            //Assert
            Assert.Empty(diceTower.Dice);
        }
    }
}