using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Factories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.CRM
{
    public class New_clientequipmemtipdataFactory
    {
        public New_clientequipmemtipdataFactory()
        {

        }
        public DTO.CRM.New_clientequipmemtipdata CreateNew_clientequipmemtipdata(New_clientequipmemtipdata entity)
        {
            return new DTO.CRM.New_clientequipmemtipdata()
            {
                New_ClientRoomIdName = entity.New_ClientRoomIdName,
                OrganizationIdName = entity.OrganizationIdName,
                new_ClientEquipmentIdName = entity.new_ClientEquipmentIdName,
                New_ProjectIdName = entity.New_ProjectIdName,
                New_ProjectRoomIdName = entity.New_ProjectRoomIdName,
                New_clientequipmemtipdataId = entity.New_clientequipmemtipdataId,
                OrganizationId = entity.OrganizationId,
                statecode = entity.statecode,
                statuscode = entity.statuscode,
                VersionNumber = entity.VersionNumber,
                New_name = entity.New_name,
                New_Hostname = entity.New_Hostname,
                New_IPAddress = entity.New_IPAddress,
                New_Subnet = entity.New_Subnet,
                New_Gateway = entity.New_Gateway,

                New_ClientRoomId = entity.New_ClientRoomId,

                New_Band = entity.New_Band,
                New_Frequency = entity.New_Frequency,
                New_FQN = entity.New_FQN,
                New_ProjectId = entity.New_ProjectId,
                New_ProjectRoomId = entity.New_ProjectRoomId,
                new_FirmwareVersion = entity.new_FirmwareVersion,
                new_Manufacturer = entity.new_Manufacturer,

                new_ModelNumber = entity.new_ModelNumber,
                new_Notes = entity.new_Notes,
                new_NetworkType = entity.new_NetworkType,
                new_ConnectionType = entity.new_ConnectionType,
                new_ClientEquipmentId = entity.new_ClientEquipmentId,
                new_SSID = entity.new_SSID,
                new_PSK = entity.new_PSK,
                new_Mask = entity.new_Mask,
                new_WirelessGateway = entity.new_WirelessGateway,
                new_IPID = entity.new_IPID,
                new_Username = entity.new_Username,
                new_Password = entity.new_Password,
                new_Gatekeeper = entity.new_Gatekeeper,
                new_OpenBatchFile = entity.new_OpenBatchFile,
                new_WANAccessIPAddress = entity.new_WANAccessIPAddress,
                new_LANAccessPort = entity.new_LANAccessPort,
                new_WANAccessPort = entity.new_WANAccessPort,
                new_DPS = entity.new_DPS,
                new_Encryption = entity.new_Encryption,
                new_BusType = entity.new_BusType,
                new_BusID = entity.new_BusID,
                new_CresnetID = entity.new_CresnetID,
                new_MACAddress = entity.new_MACAddress,
                new_InternalIP = entity.new_InternalIP,
                new_Subnet_txt = entity.new_Subnet_txt,
                new_Gateway_txt = entity.new_Gateway_txt,
                new_ExternalIP = entity.new_ExternalIP,
                new_Gatekeeper_txt = entity.new_Gateway_txt,
                new_WirelessGateway_txt = entity.new_WirelessGateway_txt,
            };
        }

        public New_clientequipmemtipdata CreateNew_clientequipmemtipdata(DTO.CRM.New_clientequipmemtipdata entity)
        {
            return new New_clientequipmemtipdata()
            {
                New_ClientRoomIdName = entity.New_ClientRoomIdName,
                OrganizationIdName = entity.OrganizationIdName,
                new_ClientEquipmentIdName = entity.new_ClientEquipmentIdName,
                New_ProjectIdName = entity.New_ProjectIdName,
                New_ProjectRoomIdName = entity.New_ProjectRoomIdName,
                New_clientequipmemtipdataId = entity.New_clientequipmemtipdataId,
                OrganizationId = entity.OrganizationId,
                statecode = entity.statecode,
                statuscode = entity.statuscode,
                VersionNumber = entity.VersionNumber,
                New_name = entity.New_name,
                New_Hostname = entity.New_Hostname,
                New_IPAddress = entity.New_IPAddress,
                New_Subnet = entity.New_Subnet,
                New_Gateway = entity.New_Gateway,

                New_ClientRoomId = entity.New_ClientRoomId,

                New_Band = entity.New_Band,
                New_Frequency = entity.New_Frequency,
                New_FQN = entity.New_FQN,
                New_ProjectId = entity.New_ProjectId,
                New_ProjectRoomId = entity.New_ProjectRoomId,
                new_FirmwareVersion = entity.new_FirmwareVersion,
                new_Manufacturer = entity.new_Manufacturer,

                new_ModelNumber = entity.new_ModelNumber,
                new_Notes = entity.new_Notes,
                new_NetworkType = entity.new_NetworkType,
                new_ConnectionType = entity.new_ConnectionType,
                new_ClientEquipmentId = entity.new_ClientEquipmentId,
                new_SSID = entity.new_SSID,
                new_PSK = entity.new_PSK,
                new_Mask = entity.new_Mask,
                new_WirelessGateway = entity.new_WirelessGateway,
                new_IPID = entity.new_IPID,
                new_Username = entity.new_Username,
                new_Password = entity.new_Password,
                new_Gatekeeper = entity.new_Gatekeeper,
                new_OpenBatchFile = entity.new_OpenBatchFile,
                new_WANAccessIPAddress = entity.new_WANAccessIPAddress,
                new_LANAccessPort = entity.new_LANAccessPort,
                new_WANAccessPort = entity.new_WANAccessPort,
                new_DPS = entity.new_DPS,
                new_Encryption = entity.new_Encryption,
                new_BusType = entity.new_BusType,
                new_BusID = entity.new_BusID,
                new_CresnetID = entity.new_CresnetID,
                new_MACAddress = entity.new_MACAddress,
                new_InternalIP = entity.new_InternalIP,
                new_Subnet_txt = entity.new_Subnet_txt,
                new_Gateway_txt = entity.new_Gateway_txt,
                new_ExternalIP = entity.new_ExternalIP,
                new_Gatekeeper_txt = entity.new_Gateway_txt,
                new_WirelessGateway_txt = entity.new_WirelessGateway_txt,
            };
        }

        public object CreateDataShapedObject(New_clientequipmemtipdata x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateNew_clientequipmemtipdata(x), listOfFields);
        }
        public object CreateDataShapedObject(DTO.CRM.New_clientequipmemtipdata x, List<string> listOfFields)
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






