﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HairManager.Application.Utils.Token;
public class TokenController
{
    private const string EmailAlias = "eml";
    private readonly double _tempoDeVidaDoTokenEmMinutos;
    private readonly string _chaveDeSeguranca;

    public TokenController(double tempoDeVidaDoTokenEmMinutos, string chaveDeSeguranca)
    {
        _tempoDeVidaDoTokenEmMinutos = tempoDeVidaDoTokenEmMinutos;
        _chaveDeSeguranca = chaveDeSeguranca;
    }

    public string GerarToken(string emailUsuario)
    {
        var claims = new List<Claim>
        {
            new Claim(EmailAlias, emailUsuario)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_tempoDeVidaDoTokenEmMinutos),
            SigningCredentials = new SigningCredentials(SimetricKey(), SecurityAlgorithms.HmacSha256Signature)
        };

        var securityTokem = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityTokem);
    }

    public void ValidarToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var parametrosValidacao = new TokenValidationParameters
        {
            RequireExpirationTime = true,
            IssuerSigningKey = SimetricKey(),
            ClockSkew = new TimeSpan(0),
            ValidateIssuer = false,
            ValidateAudience = false,
        };

        tokenHandler.ValidateToken(token, parametrosValidacao, out _);
    }

    private SymmetricSecurityKey SimetricKey()
    {
        var symmetricKey = Convert.FromBase64String(_chaveDeSeguranca);
        return new SymmetricSecurityKey(symmetricKey);
    }
}
