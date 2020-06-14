﻿using MediatR;
using SmartHub.Application.Common.Models;
using SmartHub.Domain.Common;

namespace SmartHub.Application.UseCases.Entity.Homes.Create
{
	public class HomeCreateCommand : IRequest<ServiceResponse<HomeDto>>
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public HomeCreateCommand(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
