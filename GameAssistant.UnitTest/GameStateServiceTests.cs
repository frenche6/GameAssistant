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
    public class GameStateServiceTests
    {
        [Fact]
        public async Task CreateAsync_Success()
        {
            var id = Guid.NewGuid();
            var gameStateExpected = new GameState
            {
                Id = id,
                GameName = "Monopoly",
                Title = "Kickin it old school",
                Players = new List<IPlayer>
                {
                    new Player { Name = "Martha" },
                    new Player { Name = "George" },
                    new Player { Name = "Henrietta" },
                    new Player { Name = "Bob" }
                }
            };

            var gameProvider = new Mock<IGameStateProvider>();
            gameProvider.Setup(g => g.CreateAsync(It.IsAny<GameState>())).ReturnsAsync(gameStateExpected);
            gameProvider.Setup(g => g.GetAsync(id)).ReturnsAsync(gameStateExpected);

            var service = new GameStateService(gameProvider.Object);

            await service.CreateAsync(gameStateExpected.GameName, gameStateExpected.Title, gameStateExpected.Players);
            var gameStateActual = await service.LoadGameState(id);

            Assert.Equal(gameStateExpected.GameName, gameStateActual.GameName);
            Assert.Equal(gameStateExpected.Title, gameStateActual.Title);
            Assert.Equal(gameStateExpected.Players.Count, gameStateActual.Players.Count);
        }
    }
}
