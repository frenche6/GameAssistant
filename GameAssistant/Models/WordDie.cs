using System.Collections.Generic;

namespace GameAssistant.Models
{
    public class WordDie : BaseDie<string>
    {
        /// <summary>
        /// Creates a string die based on the faces provided
        /// </summary>
        /// <param name="faces">The faces used to create a die</param>
        public WordDie(List<string> faces) : base(faces)
        {

        }
    }
}
