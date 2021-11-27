using System;
using WordSearch;
using Xunit;

namespace WordSearchTests
{
    public class SolutionTests
    {
        [Fact]
        public void FindWords_WhenWordInALineInTheGrid_ShouldBeFound()
        {
            char[,] grid = {
                {'X', 'Y', 'Z'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(0, 0);
            var expectedEndLocation = new Tuple<int, int>(2, 0);
            var expectedResult = new Result()
            {
                Word = words[0],
                StartPoint = expectedStartLocation,
                EndPoint = expectedEndLocation
            };

            var result = Solution.FindWords(grid, words);

            Assert.Single(result);
            Assert.Equal(words[0],result[0].Word);
            Assert.Equal(expectedResult,result[0]);
        }
    }
}