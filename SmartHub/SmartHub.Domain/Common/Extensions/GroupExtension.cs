﻿using SmartHub.Domain.Entities;

namespace SmartHub.Domain.Common.Extensions
{
	/// <summary>
	/// Extension methods for <see cref="Group"/> entity.
	/// </summary>
	public static class GroupExtension
	{
		/// <summary>
		/// Adds a new device.
		/// </summary>
		/// <param name="group">This group entity.</param>
		/// <param name="newDevice">The new device entity to be added.</param>
		/// <returns></returns>
		public static Group AddDevice(this Group group, Device newDevice)
		{
			group.Devices.Add(newDevice);
			return group;
		}

		/// <summary>
		/// Adds a new subGroup.
		/// </summary>
		/// <param name="group">This group entity.</param>
		/// <param name="newSubGroup">The new subGroup entity to be added.</param>
		/// <returns></returns>
		public static Group AddSubGroup(this Group group,Group newSubGroup)
		{
			group.SubGroups.Add(newSubGroup);
			return group;
		}
	}
}