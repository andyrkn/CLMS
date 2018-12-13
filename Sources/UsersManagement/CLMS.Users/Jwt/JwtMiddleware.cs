using System.Net;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.AspNetCore.Http;

namespace CLMS.Users
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        private readonly string TokenEndpoint = "/api/token";

        public JwtMiddleware(RequestDelegate next)
        {
            EnsureArg.IsNotNull(next);

            this.next = next;
        }

        public Task Invoke(HttpContext httpContext, JwtProvider jwtProvider)
        {
            if (!IsLoginRequest(httpContext.Request))
            {
                return next(httpContext);
            }

            return IsValidLoginRequest(httpContext.Request)
                ? jwtProvider.CreateToken(httpContext)
                : BadRequest(httpContext);
        }

        private bool IsLoginRequest(HttpRequest request)
        {
            return request.Path.Equals(TokenEndpoint);
        }

        private bool IsValidLoginRequest(HttpRequest request)
        {
            return request.Method.Equals("POST") && request.HasFormContentType;
        }

        private Task BadRequest(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync("Bad request");
        }
    }
}