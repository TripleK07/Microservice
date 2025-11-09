using System;

namespace EM.Core.Models.Dto;

public class RegisterationRequestDto
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
