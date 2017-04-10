using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.ConstantConnect
{
    public class RoomDetailFactory
    {
        DeviceFactory deviceFactory = new DeviceFactory();
        public DTO.ConstantConnect.RoomDetail CreateRoomDetail(RoomDetail entity)
        {
            return new DTO.ConstantConnect.RoomDetail()
            {
                CrmRoomId = entity.CrmRoomId,
                RoomName = entity.RoomName,
                RoomDescription = entity.RoomDescription,
                CrmOwnerId = entity.CrmOwnerId,
                RoomCheckReady = entity.RoomCheckReady,
                Dashboard2 = entity.Dashboard2,
                Dashboard3 = entity.Dashboard3,
                LocationId = entity.LocationId,
                UtcOffset = entity.UtcOffset,
                TestOffset = entity.TestOffset,
                Status = entity.Status,
                ServicePlan = entity.ServicePlan,

                Devices = entity.Devices.Select(e => deviceFactory.CreateDevice(e)).ToList()
            };
        }

        public RoomDetail CreateRoomDetail(DTO.ConstantConnect.RoomDetail entity)
        {
            return new RoomDetail()
            {
                CrmRoomId = entity.CrmRoomId,
                RoomName = entity.RoomName,
                RoomDescription = entity.RoomDescription,
                CrmOwnerId = entity.CrmOwnerId,
                RoomCheckReady = entity.RoomCheckReady,
                Dashboard2 = entity.Dashboard2,
                Dashboard3 = entity.Dashboard3,
                LocationId = entity.LocationId,
                UtcOffset = entity.UtcOffset,
                TestOffset = entity.TestOffset,
                Status = entity.Status,
                ServicePlan = entity.ServicePlan,

                Devices = entity.Devices == null ? new List<Device>() : entity.Devices.Select(e => deviceFactory.CreateDevice(e)).ToList()
            };
        }

        public object CreateDataShapedObject(RoomDetail x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateRoomDetail(x), listOfFields);
        }

        public object CreateDataShapedObject(DTO.ConstantConnect.RoomDetail x, List<string> listOfFields)
        {
            var listOfFieldsToWorkWith = new List<string>(listOfFields);

            if (!listOfFieldsToWorkWith.Any())
                return x;

            var listOfDeviceFields = listOfFieldsToWorkWith.Where(f => f.Contains("device")).ToList();

            bool returnPartialDevice = listOfDeviceFields.Any() && !listOfDeviceFields.Contains("device");
            
            if (returnPartialDevice)
            {
                listOfFieldsToWorkWith.RemoveRange(listOfDeviceFields);
                listOfDeviceFields = listOfDeviceFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();
            }
            else
            {
                listOfDeviceFields.Remove("device");
                listOfFieldsToWorkWith.RemoveRange(listOfDeviceFields);
            }


            ExpandoObject result = new ExpandoObject();
            foreach (var field in listOfFieldsToWorkWith)
            {
                var fieldValue = x.GetType()
                    .GetProperty(field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .GetValue(x, null);

                ((IDictionary<String, Object>)result).Add(field, fieldValue);
            }

            if (returnPartialDevice)
            {
                var devices = new List<object>();
                foreach (var device in x.Devices)
                {
                    devices.Add(deviceFactory.CreateDataShapedObject(device, listOfDeviceFields));
                }
                ((IDictionary<String, Object>)result).Add("device", devices);
            }

            return result;
        }
    }
}
