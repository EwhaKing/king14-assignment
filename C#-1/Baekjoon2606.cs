using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        List<int>[] adjacencyList = new List<int>[N + 1];
        bool[] visited = new bool[N + 1];
        int count = 0;

        for (int i = 1; i <= N; i++)
        {
            adjacencyList[i] = new List<int>();
        }

        for (int i = 0; i < M; i++)
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            adjacencyList[a].Add(b);
            adjacencyList[b].Add(a);
        }

        DFS(1, adjacencyList, visited);

        count = visited.Count(v => v) - 1; // Subtract 1 to exclude the starting node
        
        Console.Write(count);
    }

    static void DFS(int node, List<int>[] adjacencyList, bool[] visited)
    {
        visited[node] = true;

        foreach (int neighbor in adjacencyList[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, adjacencyList, visited);
            }
        }
    }
}
