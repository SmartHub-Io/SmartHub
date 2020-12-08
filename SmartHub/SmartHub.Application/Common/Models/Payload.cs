﻿using System.Collections.Generic;

namespace SmartHub.Application.Common.Models
{
	public abstract class Payload
	{
		public IReadOnlyList<UserError>? Errors { get; }
		public string? Message { get; }

		protected Payload(string? message = null, IReadOnlyList<UserError>? errors = null)
		{
			Message = message;
			Errors = errors;
		}

		protected Payload(IReadOnlyList<UserError>? errors = null)
		{
			Message = default;
			Errors = errors;
		}

		protected Payload(string? message = null)
		{
			Message = message;
			Errors = default;
		}
	}
}