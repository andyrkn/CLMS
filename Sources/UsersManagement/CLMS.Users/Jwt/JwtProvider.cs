using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CLMS.Users.Domain;
using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CLMS.Users
{
    public class JwtProvider
    {
        private readonly IUserManger userManger;

        private readonly TimeSpan tokenExpiration;
        private readonly string issuer;
        private readonly string audience;
        private readonly SigningCredentials signingCredentials;

        public JwtProvider(IUserManger userManger, IConfiguration configuration)
        {
            EnsureArg.IsNotNull(configuration);
            EnsureArg.IsNotNull(userManger);
            this.userManger = userManger;

            var jwtConfiguration = configuration.GetSection("Jwt");
            var tokenExpirationConfigValue = jwtConfiguration["TokenExpirationInHours"];

            tokenExpiration = TimeSpan.FromHours(int.Parse(tokenExpirationConfigValue));
            issuer = jwtConfiguration["Issuer"];
            audience = jwtConfiguration["Audience"];

            var privateKey = jwtConfiguration["Key"];
            var symmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(privateKey));
            signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
        }

        public Task CreateToken(HttpContext context)
        {
            string email = context.Request.Form["email"];
            string password = context.Request.Form["password"];
            var emailResult = Email.Create(email);

            var userLoginResult = emailResult.OnSuccess(x => userManger.CheckLogin(x, password));

            if (!userLoginResult.IsSuccess)
            {
                return BadCredentialsResponse(context.Response);
            }

            return GenerateToken(context.Response, userLoginResult.Value);
        }

        private Task BadCredentialsResponse(HttpResponse response)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response.WriteAsync("Invalid credentials");
        }

        private Task GenerateToken(HttpResponse response, ApplicationUser user)
        {
            var now = DateTime.Now;

            var claims = GetClaims(user, now);
            var encodedToken = GetEncodedToken(now, claims);

            var jwt = new
            {
                token = encodedToken,
                expiration = tokenExpiration.TotalSeconds
            };

            response.ContentType = "application/json";
            return response.WriteAsync(JsonConvert.SerializeObject(jwt));
        }

        private string GetEncodedToken(DateTime generationTime, IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                generationTime,
                generationTime.Add(tokenExpiration),
                signingCredentials);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }

        private IEnumerable<Claim> GetClaims(ApplicationUser user, DateTime generationTime)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Iss, issuer),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(generationTime).ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Exp,
                    new DateTimeOffset(generationTime).ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("id", user.Id.ToString()),
                new Claim("role", user.Role.ToString("G"))
            };
        }
    }
}