using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public static class Solution
    {
        public static List<Result> FindWords(char[,] grid, string[] words)
        {
            var trie = new Trie(words);
            var rows = grid.GetLength(0);
            var cols = grid.GetLength(1);
            var results = new HashSet<Result>();
            var visit = new HashSet<Tuple<int, int>>();
            Tuple<int,int> startPoint;

            void dfs(int row, int col, Node node, string word)
            {
                if (row < 0 || col < 0 || row == rows || col == cols ||
                    visit.Contains(new Tuple<int, int>(row, col)) ||
                    node.Children.All(e => e.Key != grid[row, col]))
                {
                    return;
                }

                visit.Add(new Tuple<int, int>(row, col));

                node = node.Children[grid[row, col]];
                word += grid[row, col];
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

                // Move towards 8 direction
                dfs(row - 1, col, node, word);
                dfs(row + 1, col, node, word);
                dfs(row - 1, col - 1, node, word);
                dfs(row + 1, col - 1, node, word);
                dfs(row - 1, col + 1, node, word);
                dfs(row + 1, col + 1, node, word);
                dfs(row, col - 1, node, word);
                dfs(row, col + 1, node, word);
                visit.Remove(new Tuple<int, int>(row, col));
            }

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    startPoint = new Tuple<int, int>(c, r);
                    dfs(r, c, trie.Root, "");
                }
            }
            
            return results.OrderBy(w => w.Word).ToList();
        }
    }
}