using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssistant.Models
{
    public abstract class BaseDie<T>
    {
        protected BaseDie(List<T> faces)
        {
            if (!faces?.Any() ?? true)
                throw new ArgumentOutOfRangeException(nameof(faces), "You must provide at least one face value");

            Sides = faces.Count;
            Faces = faces;
        }

        public int Sides { get; private set; }
        public List<T> Faces { get; private set; }
        public int Face { get; private set; } = 1;
        public T FaceValue => Faces[Face - 1];
        

        public T Roll()
        {
            var random = new Random();
            Face = random.Next(1, Sides + 1);
            return FaceValue;
        }

        public override string ToString()
        {
            return FaceValue.ToString();
        }
    }
}
