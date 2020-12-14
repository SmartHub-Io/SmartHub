﻿using SmartHub.Domain.Common.Enums;

namespace SmartHub.Application.UseCases.Entity.Devices
{
	/// <summary>
	/// Device create input.
	/// </summary>
	public record CreateDeviceInput(string Name,
		string? Description,
		string Ipv4,
		string CompanyName,
		string PluginName,
		PluginTypes PluginTypes,
		ConnectionTypes PrimaryConnection, ConnectionTypes SecondaryConnection, string GroupName);

	/// <summary>
	///Device update input.
	/// </summary>
	public record UpdateDeviceInput(string Id,
		string? Name,
		string? Description,
		string? Ipv4,
		ConnectionTypes? PrimaryConnection,
		ConnectionTypes? SecondaryConnection,
		string? GroupName);
}
