using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolBackend.Business.Interfaces;
using SchoolBackend.Entities.DTOs;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.Business.Services;
public sealed class AuthService(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider
    )
{
    public async Task<string> LoginAsync(LoginDto request)
    {
        AppUser? user =
            await userManager.Users
            .FirstOrDefaultAsync(p =>
                    p.Email == request.UserNameOrEmail ||
                    p.UserName == request.UserNameOrEmail);

        if (user is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı");
        }

        bool result = await userManager.CheckPasswordAsync(user, request.Password);

        if (!result)
        {
            throw new ArgumentException("Şifre yanlış");
        }

        return jwtProvider.CreateToken();
    }
}
