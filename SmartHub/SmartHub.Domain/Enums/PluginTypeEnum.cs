﻿using System;

namespace SmartHub.Domain.Enums
{
	[Flags]
	public enum PluginTypeEnum
	{
		None = 0,
		Base = 1,
		Mock = 2,
		Door = 4,
		Light = 8,
		Ht = 16, // humidity and temperature sensor
		Sensor = 32, //  default if it is not defined
		Rgb = 64, // red green blue

	}
}
