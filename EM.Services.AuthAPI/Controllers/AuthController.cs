using System.Threading.Tasks;
using EM.Core.Models.Dto;
using EM.Services.AuthAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EM.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public ResponseDto responseDto;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var response = await _authService.Login(loginRequestDto);
            responseDto = new ResponseDto
            {
                IsSuccess = response.Token != String.Empty,
                Message = response.Token != String.Empty ? "Login Successful" : "Invalid Credentials",
                Result = response
            };
            return Ok(responseDto);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterationRequestDto registrationRequestDto)
        {
            string errorMsg = await _authService.Register(registrationRequestDto);
            responseDto = new ResponseDto
            {
                IsSuccess = String.IsNullOrEmpty(errorMsg),
                Message = String.IsNullOrEmpty(errorMsg) ? "User Registered Successfully" : errorMsg
            };
            return Ok(responseDto);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(RegisterationRequestDto registerationRequestDto)
        {
            var result = await _authService.AssignRole(registerationRequestDto.UserName, registerationRequestDto.Role.ToUpper());
            responseDto = new ResponseDto
            {
                IsSuccess = result,
                Message = result ? "Role Assigned Successfully" : "Role Assigned Failed"
            };
            return Ok(responseDto);
        }
    }
}
