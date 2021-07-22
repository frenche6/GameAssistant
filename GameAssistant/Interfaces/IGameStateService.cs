using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameAssistant.Interfaces
{
    /// <summary>
    /// A service for managing and persisting the state of the game
    /// </summary>
    public interface IGameStateService
    {

        /// <summary>
        /// Sets up a new game with initial state
        /// </summary>
        /// <param name="gameName">The name of the game being played ie. Monopoly, Uno, etc.</param>
        /// <param name="title">The title for the session</param>
        /// <param name="players">A list of players in turn order</param>
        /// <returns>The created game state</returns>
        public Task<GameState> CreateAsync(string gameName, string title, IList<IPlayer> players);

        /// <summary>
        /// A separate option for persisting a provided, externally constructed game state
        /// </summary>
        /// <param name="state">The game state to persist in the provider</param>
        /// <returns>The game state saved with the id populated for lookup later</returns>
        public Task<GameState> CreateAsync(GameState state);

        /// <summary>
        /// Loads a state by Id from the provider
        /// </summary>
        /// <param name="id">The unique identifier of the gamestate to load</param>
        /// <returns>The requested GameState</returns>
        public Task<GameState> LoadGameState(Guid id);

        /// <summary>
        /// Persists changes to a game state
        /// </summary>
        /// <param name="newState">The updated state</param>
        /// <returns></returns>
        public Task UpdateGameState(GameState newState);

        /// <summary>
        /// Ends the current users turn
        /// </summary>
        /// <param name="state">The current GameState</param>
        public void EndTurn(GameState state);
    }
}
