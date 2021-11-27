using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public static class Solution
    {
        /// <summary>
        /// 1.Create a tire (prefix tree) for the list of words
        /// 2.Loop each location in the grid to find match word in the trie using DFS and Backtracking
        /// </summary>
        /// <param name="grid">A two dimensional grid that each cell of it has a char</param>
        /// <param name="words">The list of words that wants to find in the grid</param>
        /// <returns>Return a list of result that each result has the matching word, the start location and end location</returns>
        public static List<Result> FindWords(char[,] grid, string[] words)
        {
            var trie = new Trie(words);
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            var results = new HashSet<Result>();
            var visit = new HashSet<Tuple<int, int>>();
            Tuple<int,int> startPoint;

            void Dfs(int row, int col, Node node, string word)
            {
                if (row < 0 || col < 0 || row == rows || col == cols ||
                    visit.Contains(new Tuple<int, int>(row, col)) ||
                    node.Children.All(e => e.Key != grid[row, col]))
                {
                    return;
                }

                var currentLocation = new Tuple<int, int>(row, col);
                visit.Add(currentLocation);

                var currentChar = grid[row, col];
                node = node.Children[currentChar];
                word += currentChar;
                
                if (node.IsEnd)
                {
                    var result = new Result()
                    {
                        Word = word,
                        StartPoint = startPoint,
                        EndPoint = new Tuple<int, int>(col, row)
                    };
                    results.Add(result);
                }

                // Move towards 8 directions
                Dfs(row - 1, col, node, word);
                Dfs(row + 1, col, node, word);
                Dfs(row - 1, col - 1, node, word);
                Dfs(row + 1, col - 1, node, word);
                Dfs(row - 1, col + 1, node, word);
                Dfs(row + 1, col + 1, node, word);
                Dfs(row, col - 1, node, word);
                Dfs(row, col + 1, node, word);
                visit.Remove(currentLocation);
            }

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    startPoint = new Tuple<int, int>(c, r);
                    Dfs(r, c, trie.Root, "");
                }
            }
            
            return results.OrderBy(w => w.Word).ToList();
        }
    }
}