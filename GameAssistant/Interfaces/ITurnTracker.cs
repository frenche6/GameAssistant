using GameAssistant.Models;

namespace GameAssistant.Interfaces
{
    /// <summary>
    /// Manages turns and applies rules related to turn taking and ending including selecting the next active player on gamestate
    /// </summary>
    public interface ITurnTracker
    {
        /// <summary>
        /// Apply turn rules and manage state 
        /// </summary>
        /// <param name="state">The current game state to be modified</param>
        /// <returns>The modified game state</returns>
        GameState TakeTurn(GameState state);

        /// <summary>
        /// Sets next player
        /// </summary>
        /// <param name="state">The current game state with the current player turn set</param>
        /// <returns>The new game state</returns>
        GameState EndTurn(GameState state);
    }
}
