﻿using SmartHub.Domain.Common.EventTypes;
using SmartHub.Domain.Common.Extensions;
using SmartHub.Domain.Entities.Homes;
using SmartHub.Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using SmartHub.Domain.Enums;
using SmartHub.Application.Common.Interfaces.Events;
using SmartHub.Application.Common.Interfaces;
using SmartHub.Application.UseCases.Identity.Login;
using SmartHub.Application.Common.Exceptions;

namespace SmartHub.Infrastructure.Services.Dispatchers
{
	public class EventDispatcher : IEventDispatcher
	{
		private readonly IChannelManager _channelManager;
		private readonly ILogger _logger;

		public EventDispatcher(IChannelManager channelManager, ILogger logger)
		{
			_channelManager = channelManager;
			_logger = logger;
			if (_channelManager is null)
			{
				_channelManager = new ChannelManager();
			}
			_ = _channelManager
				.GetChannel(ChannelEventEnum.Events)
				.Subscribe(Dispatch);
		}

		private void Dispatch(object baseEvent)
		{
			switch (baseEvent)
			{
				case null:
					break;
				case IApplicationEvent appEvent:
					DispatchApplicationEvent(appEvent);
					break;
				case IEnumerable<IDomainEvent> events:
				{
					foreach (var item in events)
					{
						DispatchDomainEvents(item);
					}

					break;
				}
				default:
					DispatchGeneralEvent(baseEvent);
					break;
			}
		}

		private void DispatchGeneralEvent(object baseEvent)
		{
			var iEvent = baseEvent as IEvent;
			_logger.Information($"[{nameof(Dispatch)}] Dispatch {nameof(IEvent)}=> {iEvent?.GetType().Name}");
			// hier dann alle aus den events Evententitys bauen und in die db speichern
			// und an signalR geben für liveEvents
		}

		private void DispatchApplicationEvent(IApplicationEvent applicationEvent)
		{
			switch (applicationEvent)
			{
				case LoginEvent loginEvent:
					_logger.Information("[DispatchApplicationEvent] Dispatch LoginEvent =>  UserName: {@UserName}; Login state: {@Successful}; ",
						loginEvent.UserName, loginEvent.Successful
						); // hier an den jeweiligen service schicken der das event verarbeiten soll, z.B email, notification signalr
					break;
				default:
					throw new SmartHubException("Unknown event error");
			}
		}

		private void DispatchDomainEvents(IDomainEvent domainEvent)
		{
			switch (domainEvent)
			{
				case HomeUpdatedEvent homeUpdatedEvent:
					_logger.Information("[DispatchDomainEvents] Dispatch HomeUpdatedEvent => Updated home {@homeUpdatedEvent} ", homeUpdatedEvent);
                    // hier an den jeweiligen service schicken der das event verarbeiten soll, z.B email, notification, signalr
					break;

				default:
					throw new SmartHubException("Unknown event error");
			}
		}
	}
}
