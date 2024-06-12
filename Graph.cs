﻿
//based off of https://www.geeksforgeeks.org/detect-cycle-in-a-graph/
// A C# Program to detect cycle in a graph
using System;
using System.Collections.Generic;

public class Graph
{

    private int V;
    private Dictionary<int, List<int>> adj;

    public Graph(int V)
    {
        this.V = V;
        adj = new Dictionary<int, List<int>>();

        for (int i = 0; i < V; i++)
            adj.Add(i, new List<int>());
    }

    // Function to check if cycle exists
    private bool isCyclicUtil(int i, bool[] visited,
                              bool[] recStack)
    {
        // Mark the current node as visited and
        // part of recursion stack
        if (recStack[i])
            return true;

        if (visited[i])
            return false;

        visited[i] = true;

        recStack[i] = true;
        List<int> children = adj[i];

        foreach (int c in children) if (
            isCyclicUtil(c, visited, recStack)) return true;

        recStack[i] = false;

        return false;
    }

    public void addEdge(int sou, int dest)
    {
        adj[sou].Add(dest);
    }

    // Returns true if the graph contains a
    // cycle, else false
    public bool isCyclic()
    {
        // Mark all the vertices as not visited and
        // not part of recursion stack
        bool[] visited = new bool[V];
        bool[] recStack = new bool[V];

        // Call the recursive helper function to
        // detect cycle in different DFS trees
        for (int i = 0; i < V; i++)
            if (isCyclicUtil(i, visited, recStack))
                return true;

        return false;
    }

    // Driver code
    /*
    public static void Main(String[] args)
    {
        Graph graph = new Graph(4);
        graph.addEdge(0, 1);
        graph.addEdge(0, 2);
        graph.addEdge(1, 2);
        graph.addEdge(2, 0);
        graph.addEdge(2, 3);
        graph.addEdge(3, 3);

        // Function call
        if (graph.isCyclic())
            Console.WriteLine("Graph contains cycle");
        else
            Console.WriteLine("Graph doesn't "
                              + "contain cycle");
    }
    */
}
