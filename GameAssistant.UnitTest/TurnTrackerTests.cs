using GameAssistant.Interfaces;
using GameAssistant.Models;
using GameAssistant.Services;
using System.Collections.Generic;
using Xunit;

namespace GameAssistant.UnitTest
{
    public class TurnTrackerTests
    {
        [Fact]
        public void Endturn_WithPlayerList_IncrementsCurrentPlayer()
        {
            //Arrange
            var playersList = new List<IPlayer>();

            for (int i = 0; i < 3; i++)
            {
                playersList.Add(new Player());
            }

            var gameState = new GameState()
            {
                Players = playersList,
                PlayerTurn = 0
            };

            var turnTracker = new TurnTracker();

            //Act
            var actualState = turnTracker.EndTurn(gameState);

            //Assert
            Assert.Equal(1, actualState.PlayerTurn);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void Endturn_WithTurnStatePastListCount_ShouldGoToBeginning(int playerCount)
        {
            //Arrange
            var playersList = new List<IPlayer>();

            for (int i = 0; i < playerCount; i++)
            {
                playersList.Add(new Player());
            }

            var gameState = new GameState()
            {
                Players = playersList,
                PlayerTurn = playerCount - 1
            };

            var turnTracker = new TurnTracker();

            //Act
            var actualState = turnTracker.EndTurn(gameState);

            //Assert
            Assert.Equal(0, actualState.PlayerTurn);
        }
    }
}
