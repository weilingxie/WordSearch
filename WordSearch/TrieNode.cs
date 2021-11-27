using System.Collections.Generic;

namespace WordSearch
{
    public class Node
    {
        public bool IsEnd = false;
        public Dictionary<char, Node> Children = new Dictionary<char, Node>();
    }
}