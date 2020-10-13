﻿using System;
using SmartHub.Domain.Common.Enums;
using SmartHub.Domain.DomainEvents;

namespace SmartHub.Application.Common.Interfaces.Events
{
	/// <summary>
	/// Abstract Event class for all applicationEvents
	/// </summary>
	public abstract class ApplicationEvent : IBaseEvent
	{
		public virtual string EventId { get; }
		public virtual string EventType { get; set; } = EventTypes.Application.ToString();

		protected ApplicationEvent()
		{
			EventId = Guid.NewGuid().ToString();
		}
	}
}
