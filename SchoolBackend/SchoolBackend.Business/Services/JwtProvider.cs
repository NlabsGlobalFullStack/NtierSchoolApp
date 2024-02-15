using Microsoft.IdentityModel.Tokens;
using SchoolBackend.Business.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SchoolBackend.Business.Services;
public sealed class JwtProvider : IJwtProvider
{
    public string CreateToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("benim şifre anahtarım benim şifre anahtarım benim şifre anahtarım benim şifre anahtarım benim şifre anahtarım"));

        JwtSecurityToken jwtSecurityToken = new(
            issuer: "Cuma KÖSE",
            audience: "Cuma KÖSE",
            claims: null,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(jwtSecurityToken);
        return token;
    }
}
