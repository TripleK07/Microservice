using System;
using EM.Core.Models.Dto;

namespace EM.Services.AuthAPI.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    Task<string> Register(RegisterationRequestDto registerationRequestDto);
    Task<bool> AssignRole(string userName, string roleName);
}
