using BoneConnect.DataStructures.List;
using BoneConnect.Dto;
using BoneConnect.Dto.Post;
using BoneConnect.Enums;
using BoneConnect.Models.Profile;
using BoneConnect.Services.Suggestion.Abstraction;

namespace BoneConnect.Services.Suggestion;

public class SuggestionService(
    ISuggestionServiceValidator validator,
    ISuggestionListCreator suggestionListCreator,
    IGraphSuggestionListCreator graphSuggestionListCreator) : ISuggestionService
{
    public async Task<ActionResponse<ArrayList<UserPreview>>> GetSuggestions(Models.Auth.User user)
    {
        var validateResult = await validator.Validate(user);
        if (validateResult.StatusCode != StatusCodeType.Success)
            return validateResult;


        var graphSuggestionList = graphSuggestionListCreator.Create(user, 6);
        var suggestionList = await suggestionListCreator.Create(user, graphSuggestionList, 6);
        validateResult.Data = suggestionList;

        return validateResult;    
    }
}