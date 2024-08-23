﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EduManage.BusinessObjects.Settings;

namespace EduManage.Services.Helpers
{
    public class GenerateJWT(JwtSettings jwtSettings)
    {
        public string GenerateToken(string email, int lecturerId, string username)
        {
            var claims = new[]
            {
                new Claim("Id", lecturerId.ToString()),
                new Claim(ClaimTypes.Email, email),
                // new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}