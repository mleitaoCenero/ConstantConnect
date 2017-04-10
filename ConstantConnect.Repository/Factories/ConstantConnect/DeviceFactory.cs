using ConstantConnect.Repository.Entities.ConstantConnect;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ConstantConnect.Repository.Factories.ConstantConnect
{
    public class DeviceFactory
    {
        EventGroupFactory eventGroupFactory = new EventGroupFactory();

        public DTO.ConstantConnect.Device CreateDevice(Device entity)
        {
            return new DTO.ConstantConnect.Device()
            {
                DeviceId = entity.DeviceId,
                RoomId = entity.RoomId,
                EquipmentId = entity.EquipmentId,
                DeviceName = entity.DeviceName,
                DeviceDescription = entity.DeviceDescription,
                Model = entity.Model,
                SerialNumber = entity.SerialNumber,
                SubSystemId = entity.SubSystemId,
                Software = entity.Software,
                Lamp1 = entity.Lamp1,
                Lamp2 = entity.Lamp2,
                HoldMail = entity.HoldMail,
                Status = entity.Status,

                //Incident = entity.Incident.Select(e => incidentFactory.CreateIncident(e)).ToList(),
                //RoomDetail = entity.RoomDetail,
                EventGroups = entity.EventGroups.Select(e => eventGroupFactory.CreateEventGroup(e)).ToList()
            };
        }

        public Device CreateDevice(DTO.ConstantConnect.Device entity)
        {
            return new Device()
            {
                DeviceId = entity.DeviceId,
                RoomId = entity.RoomId,
                EquipmentId = entity.EquipmentId,
                DeviceName = entity.DeviceName,
                DeviceDescription = entity.DeviceDescription,
                Model = entity.Model,
                SerialNumber = entity.SerialNumber,
                SubSystemId = entity.SubSystemId,
                Software = entity.Software,
                Lamp1 = entity.Lamp1,
                Lamp2 = entity.Lamp2,
                HoldMail = entity.HoldMail,
                Status = entity.Status,

                //RoomDetail = entity.RoomDetail,
                EventGroups = entity.EventGroups == null ? new List<EventGroup>() : entity.EventGroups.Select(e => eventGroupFactory.CreateEventGroup(e)).ToList()
            };
        }

        public object CreateDataShapedObject(Device x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateDevice(x), listOfFields);
        }

        public object CreateDataShapedObject(DTO.ConstantConnect.Device x, List<string> listOfFields)
        {
            if (!listOfFields.Any())
                return x;

            ExpandoObject result = new ExpandoObject();
            foreach (var field in listOfFields)
            {
                var fieldValue = x.GetType()
                    .GetProperty(field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .GetValue(x, null);

                ((IDictionary<string, object>)result).Add(field, fieldValue);
            }

            return result;
        }
    }
}
