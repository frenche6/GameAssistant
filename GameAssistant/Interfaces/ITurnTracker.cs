using GameAssistant.Models;

namespace GameAssistant.Interfaces
{
    public interface ITurnTracker
    {
        GameState TakeTurn(GameState state);

        GameState EndTurn(GameState state);
    }
}
