using GameAssistant.Models;
using System;
using System.Threading.Tasks;

namespace GameAssistant.Interfaces
{
    /// <summary>
    /// The data persistence layer for game state
    /// </summary>
    public interface IGameStateProvider
    {
        /// <summary>
        /// Gets the game state by id
        /// </summary>
        /// <param name="id">The identifier in storage for the item</param>
        /// <returns></returns>
        Task<GameState> GetAsync(Guid id);

        /// <summary>
        /// Persists Gamestate
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        Task SaveAsync(GameState state);

        /// <summary>
        /// Creates a new GameState with an ID
        /// </summary>
        /// <param name="state">The game state to persist</param>
        /// <returns></returns>
        Task<GameState> CreateAsync(GameState state);
    }
}
