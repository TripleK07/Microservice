using System;
using EM.Core.Models.Dto;
using EM.Web.Interfaces;
using EM.Web.Utilities;
using Newtonsoft.Json;

namespace EM.Web.Services;

public class AuthService : IAuthService
{
    IBaseService _baseService;
    public AuthService(IBaseService baseService)
    {
        _baseService = baseService;
    }
    
    public async Task<bool> AssignRole(RegisterationRequestDto registerationRequestDto)
    {
        var response = await _baseService.SendAsync(new RequestDto
        {
            ApiMethod = ApiMethod.POST,
            Data = registerationRequestDto,
            Url = Common.AuthAPIBase + "api/Auth/AssignRole"
        });
        return response.IsSuccess;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var response = await _baseService.SendAsync(new RequestDto
        {
            ApiMethod = ApiMethod.POST,
            Data = loginRequestDto,
            Url = Common.AuthAPIBase + "api/Auth/Login"
        });

        if (response!= null && response.Result != null)
        {
            var jsonResult = response.Result.ToString();
            var result = JsonConvert.DeserializeObject<LoginResponseDto>(jsonResult);
            return result;
        }
        return null;
    }

    public async Task<ResponseDto> Register(RegisterationRequestDto registerationRequestDto)
    {
        var response = await _baseService.SendAsync(new RequestDto
            {
                ApiMethod = ApiMethod.POST,
                Data = registerationRequestDto,
                Url = Common.AuthAPIBase + "api/Auth/Register"
            });
        return response;
    }
}
