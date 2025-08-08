using BoneConnect.DataStructures.List;
using BoneConnect.Models.Profile;
using BoneConnect.Services.CRUD.User.Abstraction;
using BoneConnect.Services.Suggestion.Abstraction;

namespace BoneConnect.Services.Suggestion;

public class SuggestionListCreator(IUserReceiver userReceiver) : ISuggestionListCreator
{
    public async Task<ArrayList<UserPreview>> Create(Models.Auth.User user, ArrayList<string> graphSuggestions, int topN)
    {
        var allUser = await userReceiver.ReceiveAllUserAsync();

        var result = new ArrayList<UserPreview>();
        foreach (var username in graphSuggestions)
        {
            var u = await userReceiver.ReceiveUserAsync(username);
            if (u != null && u.Username != user.Username)
            {
                result.Add(new UserPreview(u));
            }
        }

        int i = 0;
        while(i < allUser.Count - 1 && result.Count < 6)
        {
            if (allUser[allUser.Count - 1 - i].Username != user.Username)
            {
                result.Add(new UserPreview(allUser[allUser.Count - 1 - i]));
            }

            i++;
        }

        return result;
    }
}