using GameAssistant.Models;
using GameAssistant.Services;

namespace GameAssistant.UnitTest
{
    public class CustomTurnTracker : TurnTracker
    {
        public override GameState TakeTurn(GameState state)
        {
            return state;
        }
    }
}
