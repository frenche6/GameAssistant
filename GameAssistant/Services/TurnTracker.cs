using GameAssistant.Interfaces;
using GameAssistant.Models;
using System.Linq;

namespace GameAssistant.Services
{
    public class TurnTracker : ITurnTracker
    {
        public GameState EndTurn(GameState state)
        {
            state.PlayerTurn = (state.PlayerTurn + 1) % state.Players.Count();
            return state;
        }
    }
}
