using System;
using System.Text.Json.Serialization;

namespace EM.Core.Models.Dto;

public class ResponseDto
{
    [JsonPropertyName("Result")]
    public object Result { get; set; }

    [JsonPropertyName("IsSuccess")]
    public bool IsSuccess { get; set; }
    [JsonPropertyName("Message")]
    public string Message { get; set; }
}
