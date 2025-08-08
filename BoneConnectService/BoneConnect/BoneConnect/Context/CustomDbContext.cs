using System.Text.Json;
using BoneConnect.DataStructures;
using BoneConnect.DataStructures.Graph;
using BoneConnect.DataStructures.Hash;
using BoneConnect.DataStructures.List;
using BoneConnect.DataStructures.Tree;
using BoneConnect.Models.Auth;
using BoneConnect.Models.Post;
using BoneConnect.Models.Profile;
using BoneConnect.Services.AuthServices.LoginService;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;

namespace BoneConnect.Context;

public class CustomDbContext
{
    private static readonly Lazy<CustomDbContext> _instance = new Lazy<CustomDbContext>(() => new CustomDbContext());

    private readonly IPasswordHasher _passwordHasher;
    
    public static CustomDbContext Instance => _instance.Value;

    public HashTable<string, User> Users { get; private set; }
    public HashTable<string, Post> Posts { get; private set; }
    public Graph<string> ConnectionGraph { get; private set; }

    private CustomDbContext()
        {
            Users = new HashTable<string, User>();
            Posts = new HashTable<string, Post>();
            ConnectionGraph = new Graph<string>();

            _passwordHasher = new CustomPasswordHasher();
            
            string jsonFilePath = "data.json";
            InitializeFromJson(jsonFilePath);
        }

        private void InitializeFromJson(string jsonFilePath)
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            var data = JsonSerializer.Deserialize<DatabaseData>(jsonData);

            foreach (var userData in data.Users)
            {
                var user = new User
                {
                    Username = userData.Username,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Email = userData.Email,
                    ProfilePic = userData.ProfilePic,
                    PasswordHash = _passwordHasher.HashPassword(userData.PasswordHash),
                    posts = new HashTable<string, PostPreview>(),
                    connections = new AVLTree<string, UserPreview>()
                };

                foreach (var postPreviewData in userData.Posts)
                {
                    user.posts.Insert(postPreviewData.Id, new PostPreview
                    {
                        Id = postPreviewData.Id,
                        Thumbnail = postPreviewData.Thumbnail
                    });
                }

                foreach (var connectionData in userData.Connections)
                {
                    user.connections.Insert(connectionData.Username, new UserPreview
                    {
                        Username = connectionData.Username,
                        ProfilePic = connectionData.ProfilePic
                    });
                }

                Users.Insert(user.Username, user);
            }

            foreach (var postData in data.Posts)
            {
                var post = new Post
                {
                    Id = postData.Id,
                    Author = new UserPreview
                    {
                        Username = postData.Author.Username,
                        ProfilePic = postData.Author.ProfilePic
                    },
                    Caption = postData.Caption,
                    Pictures = new ArrayList<string>(postData.Pictures)
                };

                Posts.Insert(post.Id, post);
            }

            foreach (var connectionData in data.Connections)
            {
                ConnectionGraph.AddEdge(connectionData.Source, connectionData.Destination);
            }

            Console.WriteLine("Database initialized successfully!");
        }

        private class DatabaseData
        {
            public List<UserData> Users { get; set; }
            public List<PostData> Posts { get; set; }
            public List<ConnectionData> Connections { get; set; }
        }

        private class UserData
        {
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string ProfilePic { get; set; }
            public string PasswordHash { get; set; }
            public List<PostPreviewData> Posts { get; set; }
            public List<ConnectionPreviewData> Connections { get; set; }
        }

        private class PostPreviewData
        {
            public string Id { get; set; }
            public string Thumbnail { get; set; }
        }

        private class ConnectionPreviewData
        {
            public string Username { get; set; }
            public string ProfilePic { get; set; }
        }

        private class PostData
        {
            public string Id { get; set; }
            public UserPreviewData Author { get; set; }
            public string Caption { get; set; }
            public List<string> Pictures { get; set; }
        }

        private class UserPreviewData
        {
            public string Username { get; set; }
            public string ProfilePic { get; set; }
        }

        private class ConnectionData
        {
            public string Source { get; set; }
            public string Destination { get; set; }
        }
}
