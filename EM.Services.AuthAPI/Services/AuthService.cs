using System;
using AutoMapper;
using EM.Core.Models.Dto;
using EM.Services.AuthAPI.Data;
using EM.Services.AuthAPI.Interfaces;
using EM.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EM.Services.AuthAPI.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthService(AppDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IJwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var dbUser = _dbContext.Users.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
        var isValid = await _userManager.CheckPasswordAsync(dbUser, loginRequestDto.Password);
        if (dbUser == null || isValid == false)
        {
            return new LoginResponseDto
            {
                User = null,
                Token = String.Empty
            };
        }
        else
        {
            return new LoginResponseDto
            {
                User = _mapper.Map<UserDto>(dbUser),
                Token = _jwtTokenGenerator.GenerateToken(dbUser)
            };
        }
    }

    public async Task<string> Register(RegisterationRequestDto registerationRequestDto)
    {
        try
        {
            ApplicationUser user = _mapper.Map<ApplicationUser>(registerationRequestDto);
            //user.UserName = registerationRequestDto.Email;

            var result = await _userManager.CreateAsync(user, registerationRequestDto.Password);
            return result.Succeeded ? String.Empty : result.Errors.FirstOrDefault()?.Description;
        }
        catch (Exception)
        {
            return "Error Occurred during Registration";
        }
    }
}
