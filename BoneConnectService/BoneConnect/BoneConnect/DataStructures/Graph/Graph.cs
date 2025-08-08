namespace BoneConnect.DataStructures.Graph;

using System;
using System.Collections.Generic;
using System.Linq;

public class Graph<T>
{
    private readonly Dictionary<T, HashSet<T>> adjacencyList;
    private readonly object lockObject = new object();
    public bool IsDirected { get; private set; }

    public Graph(bool isDirected = false)
    {
        adjacencyList = new Dictionary<T, HashSet<T>>();
        IsDirected = isDirected;
    }

    public void AddVertex(T vertex)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new HashSet<T>();
            }
        }
    }

    public async Task AddVertexAsync(T vertex)
    {
        await Task.Run(() => AddVertex(vertex));
    }

    public void AddEdge(T source, T destination)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(source))
            {
                AddVertex(source);
            }
            if (!adjacencyList.ContainsKey(destination))
            {
                AddVertex(destination);
            }

            adjacencyList[source].Add(destination);

            if (!IsDirected)
            {
                adjacencyList[destination].Add(source);
            }
        }
    }

    public async Task AddEdgeAsync(T source, T destination)
    {
        await Task.Run(() => AddEdge(source, destination));
    }

    public void RemoveVertex(T vertex)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                throw new InvalidOperationException("Vertex not found!");
            }

            adjacencyList.Remove(vertex);

            foreach (var otherVertex in adjacencyList.Keys.ToList())
            {
                adjacencyList[otherVertex].Remove(vertex);
            }
        }
    }

    public async Task RemoveVertexAsync(T vertex)
    {
        await Task.Run(() => RemoveVertex(vertex));
    }

    public void RemoveEdge(T source, T destination)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(source) || !adjacencyList.ContainsKey(destination))
            {
                throw new InvalidOperationException("Source or destination vertex not found!");
            }

            adjacencyList[source].Remove(destination);

            if (!IsDirected)
            {
                adjacencyList[destination].Remove(source);
            }
        }
    }

    public async Task RemoveEdgeAsync(T source, T destination)
    {
        await Task.Run(() => RemoveEdge(source, destination));
    }

    public HashSet<T> GetNeighbors(T vertex)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                throw new InvalidOperationException("Vertex not found!");
            }

            return new HashSet<T>(adjacencyList[vertex]);
        }
    }

    public async Task<HashSet<T>> GetNeighborsAsync(T vertex)
    {
        return await Task.Run(() => GetNeighbors(vertex));
    }

    public bool ContainsVertex(T vertex)
    {
        lock (lockObject)
        {
            return adjacencyList.ContainsKey(vertex);
        }
    }

    public async Task<bool> ContainsVertexAsync(T vertex)
    {
        return await Task.Run(() => ContainsVertex(vertex));
    }

    public bool ContainsEdge(T source, T destination)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(source) || !adjacencyList.ContainsKey(destination))
            {
                return false;
            }

            return adjacencyList[source].Contains(destination);
        }
    }

    public async Task<bool> ContainsEdgeAsync(T source, T destination)
    {
        return await Task.Run(() => ContainsEdge(source, destination));
    }

    public IEnumerable<T> GetVertices()
    {
        lock (lockObject)
        {
            return adjacencyList.Keys.ToList();
        }
    }

    public async Task<IEnumerable<T>> GetVerticesAsync()
    {
        return await Task.Run(() => GetVertices());
    }

    public IEnumerable<(T Source, T Destination)> GetEdges()
    {
        lock (lockObject)
        {
            var edges = new List<(T Source, T Destination)>();
            foreach (var source in adjacencyList.Keys)
            {
                foreach (var destination in adjacencyList[source])
                {
                    edges.Add((source, destination));
                }
            }
            return edges;
        }
    }

    public async Task<IEnumerable<(T Source, T Destination)>> GetEdgesAsync()
    {
        return await Task.Run(() => GetEdges());
    }
    
    public void EditVertex(T oldVertex, T newVertex)
    {
        lock (lockObject)
        {
            if (!adjacencyList.ContainsKey(oldVertex))
            {
                throw new InvalidOperationException("Vertex not found!");
            }

            if (adjacencyList.ContainsKey(newVertex))
            {
                throw new InvalidOperationException("New vertex already exists!");
            }

            var neighbors = adjacencyList[oldVertex];
            adjacencyList.Remove(oldVertex);

            adjacencyList[newVertex] = new HashSet<T>(neighbors);

            foreach (var vertex in adjacencyList.Keys.ToList())
            {
                if (adjacencyList[vertex].Contains(oldVertex))
                {
                    adjacencyList[vertex].Remove(oldVertex);
                    adjacencyList[vertex].Add(newVertex);
                }
            }
        }
    }

    public async Task EditVertexAsync(T oldVertex, T newVertex)
    {
        await Task.Run(() => EditVertex(oldVertex, newVertex));
    }
    
}