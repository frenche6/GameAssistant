using GameAssistant.Models;
using System;
using System.Threading.Tasks;

namespace GameAssistant.Interfaces
{
    public interface IGameStateProvider
    {
        Task<GameState> GetAsync(Guid id);
        Task SaveAsync(GameState state);
        Task<GameState> CreateAsync(GameState state);
    }
}
