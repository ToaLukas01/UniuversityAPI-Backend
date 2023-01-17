﻿
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniversityApiBackend.Models;


namespace UniversityApiBackend.Helpers
{
    public static class JWThelpers
    {

        // Cada claim es un fragmento de información sobre el usuario, como pueden ser,
        // nombre de usuario, correo electrónico, rol, localidad a la que pertenece, etc.
        public static IEnumerable<Claim> GetClaims(this UserTokens userAcconunts, Guid Id)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", userAcconunts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAcconunts.UserName),
                new Claim(ClaimTypes.Email, userAcconunts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };

            if(userAcconunts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            } 
            else if(userAcconunts.UserName == "User 1")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);
        }

        public static UserTokens GenerateTokenKey(UserTokens model, JWTsettings jwtSettings)
        {
            try
            {
                var userToken = new UserTokens();
                if(model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                // Obtain SECRET KEY
                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.UserSigningKey);
                
                Guid Id;

                // Expire in 1 Day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Validity of the Token
                userToken.Validity = expireTime.TimeOfDay;

                // Generate Our JWT
                var jwtToken = new JwtSecurityToken(
                        issuer: jwtSettings.ValidUser,
                        audience: jwtSettings.ValidAudience,
                        claims: GetClaims(model, out Id),
                        notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                        expires: new DateTimeOffset(expireTime).DateTime,
                        signingCredentials: new SigningCredentials(
                                new SymmetricSecurityKey(key),
                                SecurityAlgorithms.HmacSha256
                            )
                    );

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
                return userToken;

            }
            catch (Exception execption)
            {
                throw new Exception("Error generating the JWT", execption);
            }
        }
    }
}

