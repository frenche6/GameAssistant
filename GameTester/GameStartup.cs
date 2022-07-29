using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAssistant.Interfaces;
using GameAssistant.Models;
using GameAssistant.Services;

namespace GameTester
{
    public class GameStartup
    {
        public GameState GameState;
        public DiceTower<int> DiceTower;

        public GameStartup(IDiceResolver<int> diceResolver)
        {
            GameState = new GameState()
            {
                Title = "Totally awesome game",
                GameName = "Whose number is higher",
                Id = new Guid(),
                Players = new List<IPlayer>()
                {
                    new Player(){Name = "Timmy"},
                    new Player(){Name = "Billy"},
                    new Player(){Name = "Jessica"}
                }
                
            };
            DiceTower = new DiceTower<int>(diceResolver);
        }
    }
}
