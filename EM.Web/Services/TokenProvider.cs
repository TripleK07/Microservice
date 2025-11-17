using System;
using EM.Web.Interfaces;
using EM.Web.Utilities;

namespace EM.Web.Services;

public class TokenProvider : ITokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public void ClearToken()
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Delete(Common.TokenCookie);
    }

    public string GetToken()
    {
        bool hasToken = _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(Common.TokenCookie, out string token);
        return hasToken ? token : String.Empty;
    }

    public void SetToken(string token)
    {
        _httpContextAccessor.HttpContext.Response.Cookies.Append(Common.TokenCookie, token);
    }
}
