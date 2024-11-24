using System.IdentityModel.Tokens.Jwt;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuthorizationMiddleware> _logger;

    public AuthorizationMiddleware(RequestDelegate next, ILogger<AuthorizationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            _logger.LogWarning("Authorization token is missing.");
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Authorization token is required.");
            return;
        }

        try
        {
            // Optionally, here you can add custom logic, like logging the token or checking the user role.
            var claimsPrincipal = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            if (claimsPrincipal == null)
            {
                _logger.LogWarning("Invalid token.");
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync("Invalid token.");
                return;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Token validation failed: {ex.Message}");
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await httpContext.Response.WriteAsync("Invalid token.");
            return;
        }

        await _next(httpContext);
    }
}
