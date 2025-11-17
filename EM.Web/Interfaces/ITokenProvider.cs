using System;

namespace EM.Web.Interfaces;

public interface ITokenProvider
{
    void ClearToken();

    string GetToken();

    void SetToken(string token);
}
