using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine();
        var prufer = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToList();

        int M = prufer.Count;
        int N = M + 1;

        var freq = new int[N + 1];
        foreach (int v in prufer)
        {
            freq[v]++;
        }

        var leaves = new SortedSet<int>();
        for (int v = 1; v <= N; v++)
        {
            if (freq[v] == 0)
                leaves.Add(v);
        }

        var adj = new List<int>[N + 1];
        for (int i = 0; i <= N; i++)
            adj[i] = new List<int>();

        foreach (int c in prufer)
        {
            int leaf = leaves.Min;
            leaves.Remove(leaf);

            adj[leaf].Add(c);
            adj[c].Add(leaf);

            freq[c]--;
            if (freq[c] == 0)
                leaves.Add(c);
        }

        for (int v = 1; v <= N; v++)
        {
            adj[v].Sort();
            Console.Write($"{v}:");
            if (adj[v].Count > 0)
                Console.Write(" ");
            Console.WriteLine(string.Join(" ", adj[v]));
        }
    }
}
