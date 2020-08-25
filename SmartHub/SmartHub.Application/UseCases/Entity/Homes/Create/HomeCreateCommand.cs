﻿using MediatR;

namespace SmartHub.Application.UseCases.Entity.Homes.Create
{
	public class HomeCreateCommand : IRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool AutoDetectAddress { get; set; }

		public HomeCreateCommand(string name, string description, bool autoDetectAddress)
		{
			Name = name;
			Description = description;
			AutoDetectAddress = autoDetectAddress;
		}
	}
}
