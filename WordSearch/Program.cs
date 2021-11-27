﻿using System;

namespace WordSearch
{
    class Program
    {
        static char[,] Grid = {
            {'C', 'P', 'K', 'X', 'O', 'I', 'G', 'H', 'S', 'F', 'C', 'H'},
            {'Y', 'G', 'W', 'R', 'I', 'A', 'H', 'C', 'Q', 'R', 'X', 'K'},
            {'M', 'A', 'X', 'I', 'M', 'I', 'Z', 'A', 'T', 'I', 'O', 'N'},
            {'E', 'T', 'W', 'Z', 'N', 'L', 'W', 'G', 'E', 'D', 'Y', 'W'},
            {'M', 'C', 'L', 'E', 'L', 'D', 'N', 'V', 'L', 'G', 'P', 'T'},
            {'O', 'J', 'A', 'A', 'V', 'I', 'O', 'T', 'E', 'E', 'P', 'X'},
            {'C', 'D', 'B', 'P', 'H', 'I', 'A', 'W', 'V', 'X', 'U', 'I'},
            {'L', 'G', 'O', 'S', 'S', 'B', 'R', 'Q', 'I', 'A', 'P', 'K'},
            {'E', 'O', 'I', 'G', 'L', 'P', 'S', 'D', 'S', 'F', 'W', 'P'},
            {'W', 'F', 'K', 'E', 'G', 'O', 'L', 'F', 'I', 'F', 'R', 'S'},
            {'O', 'T', 'R', 'U', 'O', 'C', 'D', 'O', 'O', 'F', 'T', 'P'},
            {'C', 'A', 'R', 'P', 'E', 'T', 'R', 'W', 'N', 'G', 'V', 'Z'}
        };

        static string[] Words = {
            "CARPET",
            "CHAIR",
            "DOG", 
            "BALL",
            "DRIVEWAY",
            "FISHING",
            "FOODCOURT",
            "FRIDGE",
            "GOLF",
            "MAXIMIZATION",
            "PUPPY",
            "SPACE",
            "TABLE",
            "TELEVISION",
            "WELCOME",
            "WINDOW"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Word Search");

            for (var y = 0; y < Grid.GetLength(0); y++)
            {
                for (var x = 0; x < Grid.GetLength(1); x++)
                {
                    Console.Write(Grid[y, x]);
                    Console.Write(' ');
                }
                Console.WriteLine("");
            
            }

            Console.WriteLine("");
            Console.WriteLine("Found Words");
            Console.WriteLine("------------------------------");

            var result = Solution.FindWords(Grid, Words);
            //Find each of the words in the grid, outputting the start and end location of
            //each word, e.g.
            //PUPPY found at (10,7) to (10, 3) 
            result.ForEach(w =>
            {
                Console.WriteLine($"{w.Word} found at ({w.StartPoint.Item1},{w.StartPoint.Item2}) to ({w.EndPoint.Item1}, {w.EndPoint.Item2})");
            });

            Console.WriteLine("------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }
        

        // private static void FindWords()
        // {
        //     //Find each of the words in the grid, outputting the start and end location of
        //     //each word, e.g.
        //     //PUPPY found at (10,7) to (10, 3) 
        // }
        
        
    }
}
