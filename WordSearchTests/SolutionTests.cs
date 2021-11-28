using System;
using WordSearch;
using Xunit;

namespace WordSearchTests
{
    public class SolutionTests
    {
        [Fact]
        public void FindWords_WhenAWordInTheGridIsLeftToRightDirection_ShouldBeFound()
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsRightToLeftDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'Z', 'Y', 'X'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(2, 0);
            var expectedEndLocation = new Tuple<int, int>(0, 0);
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsUpToDownDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'X'},
                {'Y'},
                {'Z'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(0, 0);
            var expectedEndLocation = new Tuple<int, int>(0, 2);
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsDownToUpDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'Z'},
                {'Y'},
                {'X'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(0, 2);
            var expectedEndLocation = new Tuple<int, int>(0, 0);
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsLeftUpToRightDownDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'X','A','A'},
                {'A','Y','A'},
                {'A','A','Z'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(0, 0);
            var expectedEndLocation = new Tuple<int, int>(2, 2);
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsRightDownToLeftUpDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'Z','A','A'},
                {'A','Y','A'},
                {'A','A','X'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(2, 2);
            var expectedEndLocation = new Tuple<int, int>(0, 0);
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsRightUpToLeftDownDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'A','A','X'},
                {'A','Y','A'},
                {'Z','A','A'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(2, 0);
            var expectedEndLocation = new Tuple<int, int>(0, 2);
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
        
        [Fact]
        public void FindWords_WhenAWordInTheGridIsLeftDownToRightUpDirection_ShouldBeFound()
        {
            char[,] grid = {
                {'A','A','Z'},
                {'A','Y','A'},
                {'X','A','A'}
            };
            string[] words = {
                "XYZ"
            };
            var expectedStartLocation = new Tuple<int, int>(0, 2);
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
        
        [Fact]
        public void FindWords_WhenThreeWordsInTheGrid_ShouldBeFound()
        {
            char[,] grid = {
                {'X','A','B'},
                {'D','Y','A'},
                {'E','C','Z'}
            };
            const string word1 = "XYZ";
            const string word2 = "XAB";
            const string word3 = "BAZ";
            string[] words = {
                word1,
                word2,
                word3
            };
            var expectedStartLocationWord1 = new Tuple<int, int>(0, 0);
            var expectedEndLocationWord1 = new Tuple<int, int>(2, 2);
            var expectedResultWord1 = new Result()
            {
                Word = word1,
                StartPoint = expectedStartLocationWord1,
                EndPoint = expectedEndLocationWord1
            };
            var expectedStartLocationWord2 = new Tuple<int, int>(0, 0);
            var expectedEndLocationWord2 = new Tuple<int, int>(2, 0);
            var expectedResultWord2 = new Result()
            {
                Word = word2,
                StartPoint = expectedStartLocationWord2,
                EndPoint = expectedEndLocationWord2
            };
            var expectedStartLocationWord3 = new Tuple<int, int>(2, 0);
            var expectedEndLocationWord3 = new Tuple<int, int>(2, 2);
            var expectedResultWord3 = new Result()
            {
                Word = word3,
                StartPoint = expectedStartLocationWord3,
                EndPoint = expectedEndLocationWord3
            };

            var result = Solution.FindWords(grid, words);

            Assert.Equal(3,result.Count);
            Assert.Contains(expectedResultWord1, result);
            Assert.Contains(expectedResultWord2, result);
            Assert.Contains(expectedResultWord3, result);
        }
    }
}