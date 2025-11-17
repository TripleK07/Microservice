using System;
using EM.Core.Models.Dto;

namespace EM.Web.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    Task<ResponseDto> Register(RegisterationRequestDto registerationRequestDto);
    Task<bool> AssignRole(RegisterationRequestDto registerationRequestDto);
}
