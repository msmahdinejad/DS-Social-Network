using BoneConnect.DataStructures.List;
using BoneConnect.Services.CRUD.User;

namespace BoneConnect.Services.Suggestion.Abstraction;

public interface IGraphSuggestionListCreator
{
    ArrayList<string> Create(Models.Auth.User user, int topN);
}