﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SmartHub.Api.Installers
{
	public class ServerInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<IISOptions>(options => { });

			services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

			services.Configure<HostOptions>(configuration.GetSection("HostOptions"));

		}
	}
}
