using System.Linq;
using WordSearch;
using Xunit;

namespace WordSearchTests
{
    public class UnitTest1
    {
        [Fact]
        public void WhenInitialATrie_ShouldHaveARootNodeByDefault()
        {
            var words = new string[] { };

            var trie = new Trie(words);

            Assert.NotNull(trie.Root);
        }

        [Fact]
        public void WhenProvidesOneWord_ShouldAddNodeTreeCorrectly()
        {
            var words = new[] { "ABC" };

            var trie = new Trie(words);

            Assert.Single(trie.Root.Children);
            Assert.True(trie.Root.Children.ContainsKey('A'));
            Assert.Single(trie.Root.Children);
            var firstNode = trie.Root.Children['A'];
            Assert.Single(firstNode.Children);
            Assert.True(firstNode.Children.ContainsKey('B'));
            var secondNode = firstNode.Children['B'];
            Assert.Single(secondNode.Children);
            Assert.True(secondNode.Children.ContainsKey('C'));
        }

        [Fact]
        public void WhenProvidesOneWord_ShouldSetIsEndFlagCorrectly()
        {
            var words = new[] { "ABC" };

            var trie = new Trie(words);

            var lastNode = trie.Root.Children['A'].Children['B'].Children['C'];
            Assert.True(lastNode.IsEnd);
        }

        [Fact]
        public void WhenProvidesTwoWordsWithDifferentPrefix_ShouldAddNodeTreeCorrectly()
        {
            const string word1 = "A";
            const string word2 = "B";
            var char1 = word1[0];
            var char2 = word2[0];
            
            var words = new[] { word1, word2 };

            var trie = new Trie(words);

            Assert.Equal(2, trie.Root.Children.Count);
            Assert.True(trie.Root.Children.ContainsKey(char1));
            Assert.True(trie.Root.Children.ContainsKey(char2));
            Assert.True(trie.Root.Children[char1].IsEnd);
            Assert.True(trie.Root.Children[char2].IsEnd);
        }
        
        [Fact]
        public void WhenProvidesTwoWordsWithSamePrefix_ShouldAddNodeTreeCorrectly()
        {
            const string word1 = "AB";
            const string word2 = "AC";

            var words = new[] { word1, word2 };

            var trie = new Trie(words);

            Assert.Single(trie.Root.Children);
            Assert.True(trie.Root.Children.ContainsKey(word1[0]));
            var firstNode = trie.Root.Children[word1[0]];
            Assert.Equal(2,firstNode.Children.Count);
            Assert.True(firstNode.Children.ContainsKey(word1[1]));
            Assert.True(firstNode.Children.ContainsKey(word2[1]));
            var secondNodeWord1 = firstNode.Children[word1[1]];
            var secondNodeWord2 = firstNode.Children[word2[1]];
            Assert.True(secondNodeWord1.IsEnd);
            Assert.True(secondNodeWord2.IsEnd);
        }
    }
}