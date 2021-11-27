using System.Linq;

namespace WordSearch
{
    public class Trie
    {
        public Node Root = new Node();

        public Trie(string[] words)
        {
            foreach (var word in words)
            {
                var node = Root;
                foreach (var letter in word)
                {
                    if (node.Children.All(e => e.Key != letter))
                    {
                        var next = new Node();
                        node.Children.Add(letter, next);
                    }
                    node = node.Children[letter];
                }
                node.IsEnd = true;
            }
        }
    }
}