using System;
using System.Text.Json.Serialization;

namespace EM.Core.Models.Dto;

public class LoginResponseDto
{
    [JsonPropertyName("User")]
    public UserDto User { get; set; }

    [JsonPropertyName("Token")]
    public string Token { get; set; }
}
