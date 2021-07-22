using System.Collections.Generic;
using System.Linq;

namespace GameAssistant.Models
{
    public class NumberDie : BaseDie<int>
    {
        /// <summary>
        /// Creates an int die with faces ranging from 1 to sides
        /// </summary>
        /// <param name="sides">Numbers of sides to create</param>
        public NumberDie(int sides) 
            : base(Enumerable.Range(1, sides).ToList())
        {
            
        }

        /// <summary>
        /// Creates an int die with the faces provided
        /// </summary>
        /// <param name="faces">The faces to use on the die</param>
        public NumberDie(List<int> faces) 
            : base(faces)
        {

        }
    }
}
