using System;
using System.Linq;
using ConstantConnect.Repository.Entities.ConstantConnect;
using System.Collections.Generic;

namespace ConstantConnect.Repository.Factories.ConstantConnect
{
    public class EventFactory
    {
        public DTO.ConstantConnect.Event CreateEvent(Event entity)
        {
            return new DTO.ConstantConnect.Event()
            {
                EventId = entity.EventId,
                RoomId = entity.RoomId,
                DeviceId = entity.DeviceId,
                EventName = entity.EventName,
                EventType = entity.EventType,
                EventTime = entity.EventTime,
                StartId = entity.StartId,
                EndId = entity.EndId,
                Minuteson = entity.Minuteson,
                SourceId = entity.SourceId,
                CallId = entity.CallId,
                SourceOn = entity.SourceOn,
                CallNumber = entity.CallNumber,
                CallDisconnectReason = entity.CallDisconnectReason,
                CallDisconnectId = entity.CallDisconnectId,
                EventGroupId = entity.EventGroupId,

                //EventGroup = entity.EventGroup.Select(e => EventGroup.CreateEventGroup(e)).ToList()
            };
        }

        public Event CreateEvent(DTO.ConstantConnect.Event entity)
        {
            return new Event()
            {
                EventId = entity.EventId,
                RoomId = entity.RoomId,
                DeviceId = entity.DeviceId,
                EventName = entity.EventName,
                EventType = entity.EventType,
                EventTime = entity.EventTime,
                StartId = entity.StartId,
                EndId = entity.EndId,
                Minuteson = entity.Minuteson,
                SourceId = entity.SourceId,
                CallId = entity.CallId,
                SourceOn = entity.SourceOn,
                CallNumber = entity.CallNumber,
                CallDisconnectReason = entity.CallDisconnectReason,
                CallDisconnectId = entity.CallDisconnectId,
                EventGroupId = entity.EventGroupId,

                //EventGroup = null ? new List<EventGroup>() : entity.EventGroup.Select(e => EventGroupFactory.CreateEventGroup(e)).ToList()
            };
        }
    }
}