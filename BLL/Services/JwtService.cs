using BLL.Interfaces;
using DAL.Enums;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            //Enum.GetName(typeof(Roles), user.Role)
            // Token basé sur un User grace a la list de claims

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                //Subject = new ClaimsIdentity(claims),
                Issuer = _configuration["jwt:issuer"],
                Audience = _configuration["jwt:audience"],
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var handler = new JwtSecurityTokenHandler();
            var tok = handler.CreateToken(descriptor);
            string TokenAvance = handler.WriteToken(tok);

            // Token A la vanille

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            string jwtNature = new JwtSecurityTokenHandler().WriteToken(token);
            return TokenAvance;
        }
    }
}
