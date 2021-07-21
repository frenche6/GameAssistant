﻿using System.Collections.Generic;
using System.Linq;

namespace GameAssistant.Models
{
    public class NumberDie : BaseDie<int>
    {
        public NumberDie(int sides) 
            : base(Enumerable.Range(1, sides).ToList())
        {
            
        }

        public NumberDie(List<int> faces) 
            : base(faces)
        {

        }
    }
}
