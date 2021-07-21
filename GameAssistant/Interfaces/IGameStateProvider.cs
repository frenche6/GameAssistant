using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssistant.Interfaces
{
    interface IGameStateProvider
    {
        Task<GameState> GetAsync(Guid id);
        Task SaveAsync(GameState state);
        Task<GameState> CreateAsync(GameState state);
    }
}
