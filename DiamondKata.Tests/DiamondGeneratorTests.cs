using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DiamondKata.Tests
{
    public class DiamondGeneratorTests
    { 
        DiamondGenerator generator = new DiamondGenerator();

        [Fact]
        public void Generate_ReturnsValidDiamond()
        {
            var expectedValue = @"  A  
 B B 
C   C
 B B 
  A  
";
            var result = generator.Generate('C');

            result.Should().Be(expectedValue);

        }

        [Fact]
        public void Generate_LetterA_ReturnsCorrectResult()
        {
            var result = generator.Generate('A');

            result.Should().Be("A");
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void Generate_ReturnsCorrectNewLines(char letter, int index)
        {
            var result = generator.Generate(letter)
                .Count(x => x.Equals('\n'));

            result.Should().Be((index * 2) + 1);
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void Generate_ReturnsCorrectCharacterTotal(char letter, int index)
        {
            var result = generator.Generate(letter);

            for (int i = index; i > 0; i--)
            {
                var characterCount = result.Count(x => x.Equals(DiamondGenerator.Characters[index]));
                characterCount.Should().Be(2);
            }
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void Generate_ReturnsCorrectWhitespaceTotal(char letter, int index)
        {
            var expectedResult = (4 * (index * index)) + 1;

            var result = generator.Generate(letter)
                .Count(x => x.Equals(' '));

            result.Should().Be(expectedResult);
        }
    }

    public class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 1; i < DiamondGenerator.Characters.Length; i++)
            {
                yield return new object[] { DiamondGenerator.Characters[i], i };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}