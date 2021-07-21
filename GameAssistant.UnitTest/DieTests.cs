using System;
using System.Collections.Generic;
using GameAssistant.Models;
using Xunit;

namespace GameAssistant.UnitTest
{
    public class DieTests
    {
        [Fact]
        public void DieConstructor_EmptyFaces_ThrowsArgumentOutOfRangeException()
        {
            var faces = new List<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => new NumberDie(faces));
        }

        [Fact]
        public void DieConstructor_NullFaces_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new NumberDie(null));
        }

        [Fact]
        public void DieConstructor_HasFaces_CreatesDie()
        {
            var faces = new List<int>() {2,4,6,8,10,12};
            var die = new NumberDie(faces);
            Assert.NotNull(die);
            Assert.Equal(faces.Count, die.Sides);
            Assert.Equal(faces[0], die.FaceValue);
            Assert.Equal(1, die.Face);
            Assert.Equal("2", die.ToString());

        }

        [Fact]
        public void DieConstructor_GivenSideCount_CreatesDie()
        {
            var sideCount = 6;
            var die = new NumberDie(sideCount);
            Assert.NotNull(die);
            Assert.Equal(sideCount, die.Sides);
            Assert.Equal(1, die.FaceValue);
            Assert.Equal(1, die.Face);
            Assert.Equal("1", die.ToString());
        }

        [Fact]
        public void DieConstructor_GivenStringList_CreatesWordDie()
        {
            var sides = new List<string>() {"Side1", "Side2", "Side3"};
            var die = new WordDie(sides);
            Assert.NotNull(die);
            Assert.Equal("Side1", die.FaceValue);
            Assert.Equal(1, die.Face);
            Assert.Equal("Side1", die.ToString());
        }

        [Fact]
        public void DieRoll_GeneratesFaceAndFaceValue_NoErrors()
        {
            var faces = new List<int>() { 10, 20, 30 };
            var die = new NumberDie(faces);
            var result = die.Roll();
            Assert.Contains(result, faces);
            Assert.Equal(die.Face, faces.IndexOf(result) + 1);
            Assert.Equal(die.FaceValue, result);
        }

        
    }
}
