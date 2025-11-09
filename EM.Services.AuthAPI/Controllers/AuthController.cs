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
            if (errorMsg != String.Empty)
            {
                responseDto = new ResponseDto
                {
                    IsSuccess = false,
                    Message = errorMsg
                };
                return BadRequest(responseDto);
            }
            else
            {
                responseDto = new ResponseDto
                {
                    IsSuccess = true,
                    Message = "User Registered Successfully"
                };
                return Ok(responseDto);
            }
        }
    }
}
