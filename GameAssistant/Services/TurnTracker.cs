using GameAssistant.Interfaces;
using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssistant.Services
{
    class TurnTracker : ITurnTracker
    {
        public GameState EndTurn(GameState state)
        {
            //TODO: modify state
            return state;
        }
    }
}
