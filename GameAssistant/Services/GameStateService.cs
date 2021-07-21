using GameAssistant.Interfaces;
using GameAssistant.Models;
using System;
using System.Collections.Generic;
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

        public async Task<GameState> CreateAsync(string gameName, string title, IList<IPlayer> players)
        {
            var gameState = new GameState()
            {
                GameName = gameName,
                Title = title,
                Players = players
            };
            return await CreateAsync(gameState);
        }

        public async Task<GameState> CreateAsync(GameState state)
        {
            return await  _gameStateProvider.CreateAsync(state);
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
