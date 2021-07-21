using GameAssistant.Interfaces;
using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAssistant.Services
{
    public class GameStateService
    {
        private readonly IGameStateProvider _gameStateProvider;
        private readonly ITurnTracker _turnTracker;

        public GameStateService(IGameStateProvider gameStateProvider, ITurnTracker turnTracker)
        {
            this._gameStateProvider = gameStateProvider;
            this._turnTracker = turnTracker;
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
            _turnTracker.EndTurn(state);  
        }

    }
}
