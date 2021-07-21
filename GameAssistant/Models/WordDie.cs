using System.Collections.Generic;

namespace GameAssistant.Models
{
    public class WordDie : BaseDie<string>
    {
        public WordDie(List<string> faces) : base(faces)
        {

        }
    }
}
