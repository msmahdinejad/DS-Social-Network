using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BoneConnect.Services.AuthServices.LoginService.Abstraction;
using BoneConnect.Settings.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BoneConnect.Services.AuthServices.LoginService;


public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly SigningCredentials _creds;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        _creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public string GenerateJwtToken(Models.Auth.User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Username.ToString())
        };

        var token = TokenGenerator(claims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private SecurityToken TokenGenerator(List<Claim> claims)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
            SigningCredentials = _creds
        };

        var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
        return token;
    }
}