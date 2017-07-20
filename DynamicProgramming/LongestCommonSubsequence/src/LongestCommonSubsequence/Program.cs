using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Dynamic Programming
/// Longest Common Subsequence
/// </summary>
namespace LongestCommonSubsequence
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test 1
            char[] colSequence = new char[] { 'A','C','C','G','T' }; 
            char[] rowSequence = new char[] { 'C', 'A', 'G', 'T' };

            Console.WriteLine(GetLCS(colSequence, rowSequence));
        }

        public static string GetLCS(char[] colSequence, char[] rowSequence)
        {
            // C# initializes all elements with zeros
            // matrix order should be one greater than the sequence lengths as zeroth row and column are set to zero
            int[,] matrix = new int[rowSequence.Length + 1, colSequence.Length + 1];

            // Build matrix
            for (int i = 1; i <= rowSequence.Length; i++)
            {
                for (int j = 1; j <= colSequence.Length; j++)
                {
                    // since matrix's zeroth row and index are already initialized, starting from row 1 and col 1
                    // however comparison of sequences should begin from zeroth index
                    // therefore comparing by decrementing the index
                    if (rowSequence[i - 1] == colSequence[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else if (matrix[i - 1, j] >= matrix[i, j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                    else
                    {
                        matrix[i, j] = matrix[i, j - 1];
                    }
                }
            }

            /*
             *      0   A   C   C   G   T
             *  0   0   0   0   0   0   0
             *  C   0   0   1   1   1   1
             *  A   0   1   1   1   1   1
             *  G   0   1   1   1   2   2
             *  T   0   1   1   1   2   3
             * */

            // print Longest common Subsequence
            string LCS = string.Empty;
            int row = rowSequence.Length;
            int col = colSequence.Length;
            while (row + col > 0 && row > 0 && col > 0)
            {
                if (matrix[row, col] == matrix[row, col - 1])
                {
                    col--;
                }
                else if (matrix[row, col] == matrix[row - 1, col])
                {
                    row--;
                }
                else // this means matrix[row,col] == matrix[row-1,col-1] + 1
                {
                    LCS = colSequence[col - 1].ToString() + LCS;
                    col--;
                    row--;
                }
            }

            return LCS;
        }
    }
}
