using ConstantConnect.Repository.Entities.ConstantConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.ConstantConnect
{
    public class EventGroupFactory
    {
        EventFactory events = new EventFactory();

        public DTO.ConstantConnect.EventGroup CreateEventGroup(EventGroup entity)
        {
            return new DTO.ConstantConnect.EventGroup()
            {
                EventGroupId = entity.EventGroupId,
                StartCode = entity.StartCode,
                StartId = entity.StartId,
                EndId = entity.EndId,
                DeviceId = entity.DeviceId,
                EventStart = entity.EventStart,
                EventEnd = entity.EventEnd,
                MinutesOn = entity.MinutesOn,
                CallNumber = entity.CallNumber,
                CallDisconnectReason = entity.CallDisconnectReason,
                //Device = entity.Device,
                Events = entity.Events.Select(e => events.CreateEvent(e)).ToList()

            };
        }

        public EventGroup CreateEventGroup(DTO.ConstantConnect.EventGroup entity)
        {
            return new EventGroup()
            {
                EventGroupId = entity.EventGroupId,
                StartCode = entity.StartCode,
                StartId = entity.StartId,
                EndId = entity.EndId,
                DeviceId = entity.DeviceId,
                EventStart = entity.EventStart,
                EventEnd = entity.EventEnd,
                MinutesOn = entity.MinutesOn,
                CallNumber = entity.CallNumber,
                CallDisconnectReason = entity.CallDisconnectReason,
                //Device = entity.Device,
                Events = entity.Events == null ? new List<Event>() : entity.Events.Select(e => events.CreateEvent(e)).ToList()
            };
        }

    }


}
