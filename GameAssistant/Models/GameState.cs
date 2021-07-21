using GameAssistant.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameAssistant.Models
{
    public class GameState
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The name of the game being played
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// The name for this instance of the game
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Players listed in turn order
        /// </summary>
        public IList<IPlayer> Players { get; set; }

        /// <summary>
        /// The player who's turn it is
        /// </summary>
        public IPlayer CurrentPlayer => Players[PlayerTurn];

        /// <summary>
        /// The index of the current player who's turn it is in the players list
        /// </summary>
        public int PlayerTurn { get; set; }
    }
}
