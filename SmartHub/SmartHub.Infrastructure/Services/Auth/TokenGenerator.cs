﻿using SmartHub.Application.Common.Exceptions;
using SmartHub.Application.Common.Interfaces;
using SmartHub.Domain.Common.Settings;
using SmartHub.Domain.Entities.Users;
using SmartHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SmartHub.Infrastructure.Utils;

namespace SmartHub.Infrastructure.Services.Auth
{
	public class TokenGenerator : ITokenGenerator
	{
		private readonly JwtSettings _jwtSettings;

		public TokenGenerator(JwtSettings jwtSettings)
		{
			_jwtSettings = jwtSettings;
		}

		public string CreateJwtToken(User user)
		{
			if (user == null)
			{
				throw new SmartHubException(nameof(CreateJwtToken), "The given user is null");
			}
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTimeUtils.Now.ToDateTimeUtc().AddHours(JwtExpireTimeEnum.HoursToExpire.GetValue()),
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public string GenerateToken(int size = 32)
		{
			var randomNumber = new byte[size];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
	}
}
