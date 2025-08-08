using BoneConnect.Context;
using BoneConnect.DataStructures.Graph;
using BoneConnect.DataStructures.List;
using BoneConnect.Services.Suggestion.Abstraction;

namespace BoneConnect.Services.Suggestion;

public class GraphSuggestionListCreator : IGraphSuggestionListCreator
{
    public ArrayList<string> Create(Models.Auth.User user,  int topN = 6)
    {
        var context = CustomDbContext.Instance;
        var graph = context.ConnectionGraph;
        
        var suggestions = new Dictionary<string, double>();
        var userConnections = graph.GetNeighbors(user.Username);

        foreach (var connection in userConnections)
        {
            var secondDegreeConnections = graph.GetNeighbors(connection);
            foreach (var secondDegreeConnection in secondDegreeConnections)
            {
                if (!secondDegreeConnection.Equals(user) && !userConnections.Contains(secondDegreeConnection))
                {
                    var commonConnections = GetCommonConnections(graph, user.Username, secondDegreeConnection);
                    var totalConnections = GetTotalConnections(graph, user.Username, secondDegreeConnection);
                    var score = (double)commonConnections / totalConnections;

                    if (!suggestions.ContainsKey(secondDegreeConnection))
                    {
                        suggestions[secondDegreeConnection] = score;
                    }
                    else
                    {
                        suggestions[secondDegreeConnection] += score;
                    }
                }
            }
        }

        var sortedSuggestions = suggestions
            .OrderByDescending(x => x.Value)
            .Take(topN)
            .Select(x => x.Key)
            .ToList();

        return new ArrayList<string>(sortedSuggestions);
    }

    private int GetCommonConnections(Graph<string> graph, string user1, string user2)
    {
        var connections1 = graph.GetNeighbors(user1);
        var connections2 = graph.GetNeighbors(user2);
        return connections1.Intersect(connections2).Count();
    }

    private int GetTotalConnections(Graph<string> graph, string user1, string user2)
    {
        var connections1 = graph.GetNeighbors(user1);
        var connections2 = graph.GetNeighbors(user2);
        return connections1.Union(connections2).Count();
    }
}