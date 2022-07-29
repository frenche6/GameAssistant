using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAssistant.Interfaces;
using GameAssistant.Models;

namespace GameAssistant.Providers
{
    public abstract class GameStateProvider : IGameStateProvider
    {
        public abstract Task<GameState> CreateAsync(GameState state);

        public abstract Task<GameState> GetAsync(Guid id);

        public abstract Task SaveAsync(GameState state);
    }
}
