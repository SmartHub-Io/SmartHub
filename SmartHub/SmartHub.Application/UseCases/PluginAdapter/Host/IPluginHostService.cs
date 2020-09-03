﻿using SmartHub.Application.UseCases.PluginAdapter.Loader;
using SmartHub.BasePlugin;
using SmartHub.BasePlugin.Interfaces.DeviceTypes;

namespace SmartHub.Application.UseCases.PluginAdapter.Host
{
	/// <summary>
	/// Service for holding infos about available plugins
	/// Here you can load a specific plugin
	/// </summary>
	public interface IPluginHostService
	{
		IPluginLoadService<IPlugin> Plugins { get; }
		/// <summary>
		/// Loads only light plugins
		/// </summary>
		IPluginLoadService<ILight> LightPlugins { get; }

		/// <summary>
		/// Loads only door plugins
		/// </summary>
		IPluginLoadService<IDoor> DoorPlugins { get; }

	}
}
