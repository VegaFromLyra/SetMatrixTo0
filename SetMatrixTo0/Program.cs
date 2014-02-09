using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a M x N matrix,  write a method such if that an element is 0, its entire row and column are set to 0

//Brute force
//For i = 0 to less than M,
// if row[i] has any 0 element then SetZero(row[i])

//For j = 0 tp less than N,
//  if column[j] has any 0 element then SetZero(column[j])

//Time complexity: O(n ^ 2) to check for 0 in all rows since for M rows, we check N elements in each row = O(m * n) ~ O(n * n)
//O(n) to set 0

//The problem with this approach is a lot more cells of the matrix will be set to 0 than needed. 

//To solve that problem, first determine which rows and columns have 0's. Track this information 
//in a boolean array (one for all rows and one for all columns)

// Then make a second pass of the matrix and set a cell to 0 
// if its row or column is 0

//1 2  3 4 
//5 0  6 7
//8 9 10 11

//      0  1  2
//row = f, t, f

//         0  1  2  3
//column = f, t, f, f

//1 0  3  4 
//0 0  0  0
//8 0 10 11
namespace SetMatrixTo0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
                                    { {1, 2, 3, 4},
                                      {5, 0, 6, 7},
                                      {8, 9, 10, 11}
                                    };

            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            SetZeros(matrix, M, N);

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void SetZeros(int[,] matrix, int M, int N)
        {

            bool[] row = new bool[M];
            bool[] column = new bool[N];

            // Store the row and column positions in a 
            // row boolean flag and a column boolean flag
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = true;
                        column[i] = true;
                    }
                }
            }

            // Now make another pass through the array and set the cell 
            // to 0 which has either row or column flag set
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (row[i] || column[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
    }
}
