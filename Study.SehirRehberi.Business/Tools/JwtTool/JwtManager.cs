using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Study.SehirRehberi.Business.StringInfo.JwtInfo;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Study.SehirRehberi.Business.Tools.JwtTool
{
    public class JwtManager : IJwtService
    {
        public JwtToken GenerateJwt(User user)
        {

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(JwtInfo.Issuer, JwtInfo.Audience, SetClaims(user), DateTime.Now, DateTime.Now.AddMinutes(30), signingCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtToken token = new JwtToken()
            {
                Token = tokenHandler.WriteToken(jwtSecurityToken)
            };
            return token;

        }

        private List<Claim> SetClaims(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            return claims;
        }
    }
}
