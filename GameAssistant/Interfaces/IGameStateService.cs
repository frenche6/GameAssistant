using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameAssistant.Interfaces
{
    public interface IGameStateService
    {
        public Task<GameState> CreateAsync(string gameName, string title, IList<IPlayer> players);
        public Task<GameState> CreateAsync(GameState state);
        public Task<GameState> LoadGameState(Guid id);
        public Task UpdateGameState(GameState newState);
        public void EndTurn(GameState state);
    }
}
