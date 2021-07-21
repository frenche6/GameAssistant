using GameAssistant.Models;

namespace GameAssistant.Interfaces
{
    public interface ITurnTracker
    {
        GameState EndTurn(GameState state);
    }
}
