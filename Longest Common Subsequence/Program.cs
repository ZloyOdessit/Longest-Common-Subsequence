using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Common_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input_1 = Console.ReadLine();
            string input_2 = Console.ReadLine();

            char[] array_input_1 = input_1.ToCharArray();
            char[] array_input_2 = input_2.ToCharArray();
             
            int[] count = new int[Math.Max(array_input_1.Length + 1, array_input_2.Length + 1)];
            int[,] longest_LCS = new int[array_input_1.Length + 1, array_input_2.Length + 1];

            for (int i = 0; i < count.Length; i++)
            {
                count[i] = 0;
            }


            //Main thing, this should start work someday! XD
            for (int i = 0; i <= array_input_1.Length - 1; i++)
            {
                for (int j = 0; j <= array_input_2.Length - 1; j++)
                {
                    if (array_input_1[i] == array_input_2[j])
                    {
                        longest_LCS[i + 1, j + 1] = longest_LCS[i, j] + 1;
                    }
                    else
                    {
                        longest_LCS[i + 1, j + 1] = Math.Max(longest_LCS[i + 1, j], longest_LCS[i, j + 1]);
                    }
                }
            }

            int row = array_input_1.Length;
            int col = array_input_2.Length;
            string result = "";

            while (row > 0 && col > 0)
            {
                if (array_input_1[row - 1] == array_input_2[col - 1])
                {
                    result = array_input_1[row - 1] + result;
                    row--;
                    col--;
                }
                else if (longest_LCS[row - 1, col] >= longest_LCS[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Result LCS:");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
