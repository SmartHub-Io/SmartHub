﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartHub.Application.Common.Interfaces;
using SmartHub.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartHub.Infrastructure.Services.Identity
{
	public class IdentityService : IIdentityService
	{
		private readonly TokenGenerator _tokenGenerator;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly SignInManager<User> _signInManager;

		public IdentityService(UserManager<User> userManager, RoleManager<Role> roleManager, TokenGenerator tokenGenerator, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_tokenGenerator = tokenGenerator;
			_signInManager = signInManager;
		}
		public async Task<bool> CreateUser(User user, string pw, string roleName)
        {
        	var roleExist = await _roleManager.RoleExistsAsync(roleName);
        	if (!roleExist)
        	{
        		var role = new Role(roleName, $"This is the {roleName} role");
        		await _roleManager.CreateAsync(role);
        	}

        	var result = await _userManager.CreateAsync(user, pw);
        	if (result.Succeeded)
        	{
        		var addedToRole = await _userManager.AddToRoleAsync(user, roleName);
        		return addedToRole.Succeeded;
        	}
        	return false;
        }

        public async Task<bool> UpdateUser(User user)
        {
	        var result = await _userManager.UpdateAsync(user);
	        return result.Succeeded;
        }

        public async Task<IEnumerable<string>> GetUserRoles(User user)
        {
	        return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> UserChangeRole(User user, string newRoleName)
        {
        	var exists = await _roleManager.RoleExistsAsync(newRoleName);
            if (!exists)
            {
	            var role = new Role(newRoleName, $"This is the {newRoleName} role");
	            await _roleManager.CreateAsync(role);
            }
        	var roles = await _userManager.GetRolesAsync(user);
        	var resultRemoved = await _userManager.RemoveFromRoleAsync(user, roles[0]); // because the user can only have one role atm
        	if (!resultRemoved.Succeeded)
        	{
        		return false;
        	}
        	var resultAdd = await _userManager.AddToRoleAsync(user, newRoleName);
        	return resultAdd.Succeeded;
        }

        public async Task<string> CreateAuthResponse(User user, List<string>? inputRoles = default)
        {
	        var roles = inputRoles ?? await GetUserRoles(user);
	        var claims = await _userManager.GetClaimsAsync(user) as List<Claim>;
	        return  _tokenGenerator.CreateJwtToken(user, roles.ToList(), claims ?? new List<Claim>());
        }

        public async Task<bool> LoginAsync(User user, string password)
        {
	        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
	        return result.Succeeded;
        }

        public async Task<bool> UsersExist()
        {
	        return await _userManager.Users.AnyAsync();
        }

        public async Task<User?> FindByNameAsync(string username)
        {
	        return await _userManager.FindByNameAsync(username);
        }

        public async Task<User?> FindByIdAsync(string userId)
        {
	        return await _userManager.FindByIdAsync(userId);
        }
	}
}