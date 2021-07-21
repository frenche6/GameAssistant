using GameAssistant.Interfaces;
using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssistant.Services
{
    class GameStateService
    {
        private IGameStateProvider _gameStateProvider;
        public GameStateService(IGameStateProvider gameStateProvider)
        {
            this._gameStateProvider = gameStateProvider;
        }

        public async Task CreateAsync(string gameName, string title, IList<IPlayer> players)
        {
            var gameState = new GameState()
            {
                GameName = gameName,
                Title = title,
                Players = players
            };
            await CreateAsync(gameState);
        }

        public async Task CreateAsync(GameState state)
        {
            await _gameStateProvider.CreateAsync(state);
        }

        public async Task<GameState> LoadGameState(Guid id)
        {
            return await _gameStateProvider.GetAsync(id);
        }

        public async Task UpdateGameState(GameState newState)
        {
            await _gameStateProvider.SaveAsync(newState);
        }

        public virtual void EndTurn(GameState state)
        {
            state.PlayerTurn = state.PlayerTurn + 1 % state.Players.Count();
        }

    }
}
