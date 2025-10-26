using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'downToZero' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int downToZero(int n)
    {
        if (n == 0) return 0;

        Queue<(int, int)> queue = new Queue<(int, int)>();
        bool[] visited = new bool[n + 1];

        queue.Enqueue((n, 0));
        visited[n] = true;

        while (queue.Count > 0)
        {
            var (x, steps) = queue.Dequeue();

            if (x == 0)
                return steps;

            if (x - 1 >= 0 && !visited[x - 1])
            {
                visited[x - 1] = true;
                queue.Enqueue((x - 1, steps + 1));
            }

            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    int next = Math.Max(i, x / i);
                    if (!visited[next])
                    {
                        visited[next] = true;
                        queue.Enqueue((next, steps + 1));
                    }
                }
            }
        }

        return -1; 
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.downToZero(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
