using System;
using System.Collections.Generic;
using System.Linq;

namespace GameAssistant.Models
{
    public abstract class BaseDie<T>
    {
        /// <summary>
        /// Sets sides and faces of the die based on input
        /// </summary>
        /// <param name="faces">The faces to set on each face of the die</param>
        protected BaseDie(List<T> faces)
        {
            if (!faces?.Any() ?? true)
                throw new ArgumentOutOfRangeException(nameof(faces), "You must provide at least one face value");

            Sides = faces.Count;
            Faces = faces;
        }

        /// <summary>
        /// The number of sides on the die
        /// </summary>
        public int Sides { get; private set; }

        /// <summary>
        /// The meaning of the faces on each side of the die
        /// </summary>
        public List<T> Faces { get; private set; }

        /// <summary>
        /// The current face that the die is currently showing
        /// </summary>
        public int Face { get; private set; } = 1;

        /// <summary>
        /// The current value of the face that the die is currently showing
        /// </summary>
        public T FaceValue => Faces[Face - 1];
        
        /// <summary>
        /// Generates a random FaceValue, within the list of faces
        /// </summary>
        /// <returns>A face value on the die</returns>
        public T Roll()
        {
            var random = new Random();
            Face = random.Next(1, Sides + 1);
            return FaceValue;
        }

        /// <summary>
        /// Provides a string value of the die
        /// </summary>
        /// <returns>String value of FaceValue</returns>
        public override string ToString()
        {
            return FaceValue.ToString();
        }
    }
}
