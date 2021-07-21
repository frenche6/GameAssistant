using GameAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssistant.Interfaces
{
    public interface ITurnTracker
    {
        GameState EndTurn(GameState state);
    }
}
