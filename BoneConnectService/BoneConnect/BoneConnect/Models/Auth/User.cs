using System.ComponentModel.DataAnnotations;
using BoneConnect.DataStructures.Hash;
using BoneConnect.DataStructures.List;
using BoneConnect.DataStructures.Tree;
using BoneConnect.Models.DataStructures;
using BoneConnect.Models.Profile;

namespace BoneConnect.Models.Auth;

public class User
{
    [Key] [StringLength(50)] public string Username { get; set; }
    [Required] public string ProfilePic { get; set; }
    [Required] [StringLength(256)] public string PasswordHash { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }

    [Required] public HashTable<string, PostPreview> posts { get; set; } = new HashTable<string, PostPreview>();

    [Required] public AVLTree<string, UserPreview> connections { get; set; } = new AVLTree<string, UserPreview>();
}