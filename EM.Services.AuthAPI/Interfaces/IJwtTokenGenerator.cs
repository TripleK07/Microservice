using System;
using EM.Services.AuthAPI.Models;

namespace EM.Services.AuthAPI.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(ApplicationUser user);
}
