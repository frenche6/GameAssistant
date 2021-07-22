using GameAssistant.Interfaces;
using GameAssistant.Models;
using System.Linq;

namespace GameAssistant.Services
{
    /// <inheritdoc />
    public abstract class TurnTracker : ITurnTracker
    {

        public abstract GameState TakeTurn(GameState state);

        public virtual GameState EndTurn(GameState state)
        {
            state.PlayerTurn = (state.PlayerTurn + 1) % state.Players.Count();
            return state;
        }
    }
}
