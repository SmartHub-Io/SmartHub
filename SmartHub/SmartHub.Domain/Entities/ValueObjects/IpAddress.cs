﻿using System.Collections.Generic;

namespace SmartHub.Domain.Entities.ValueObjects
{
	public class IpAddress : ValueObject
	{
		public string Ipv4 { get; }

		public IpAddress(string value)
		{
			Ipv4 = value;
		}

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Ipv4;
		}
	}
}
