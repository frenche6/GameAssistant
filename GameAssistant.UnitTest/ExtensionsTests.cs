using GameAssistant.Extensions;
using GameAssistant.Interfaces;
using GameAssistant.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GameAssistant.UnitTest
{
    public class ExtensionsTests
    {
        [Fact]
        public void ConfigureGameAssistant_Success()
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureGameAssistant(new GameStateProvider(), new CustomTurnTracker())
                .BuildServiceProvider();

            var provider = serviceProvider.GetService<IGameStateProvider>();
            Assert.NotNull(provider);

            var service = serviceProvider.GetService<IGameStateService>();
            Assert.NotNull(service);

            var tracker = serviceProvider.GetService<ITurnTracker>();
            Assert.NotNull(tracker);
        }
    }

    public class GameStateProvider : IGameStateProvider
    {
        public Task<GameState> CreateAsync(GameState gameState)
        {
            return Task.FromResult(gameState);
        }

        public Task<GameState> GetAsync(Guid id)
        {
            return Task.FromResult(new GameState());
        }

        public Task SaveAsync(GameState gameState)
        {
            return Task.FromResult(gameState);
        }
    }
}
