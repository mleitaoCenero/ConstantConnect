using ConstantConnect.Repository.Entities.ConstantConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.ConstantConnect
{
    public class RoomSummaryFactory
    {
        RoomDetailFactory roomDetail = new RoomDetailFactory();
        public DTO.ConstantConnect.RoomSummary CreateRoomSummary(RoomSummary entity)
        {
            return new DTO.ConstantConnect.RoomSummary()
            {
                LineId = entity.LineId,
                RoomId = entity.RoomId,
                RoomName = entity.RoomName,
                VtcStatus = entity.VtcStatus,
                AtcStatus = entity.AtcStatus,
                ControlStatus = entity.ControlStatus,
                PresentationStatus = entity.PresentationStatus,
                OnlineStatus = entity.OnlineStatus,
                TestDate = entity.TestDate,
                CrmProjectRoomId = entity.CrmProjectRoomId,
                RoomViewRoomId = entity.RoomViewRoomId
            };
        }

        public RoomSummary CreateRoomSummary(DTO.ConstantConnect.RoomSummary entity)
        {
            return new RoomSummary()
            {
                LineId = entity.LineId,
                RoomId = entity.RoomId,
                RoomName = entity.RoomName,
                VtcStatus = entity.VtcStatus,
                AtcStatus = entity.AtcStatus,
                ControlStatus = entity.ControlStatus,
                PresentationStatus = entity.PresentationStatus,
                OnlineStatus = entity.OnlineStatus,
                TestDate = entity.TestDate,
                CrmProjectRoomId = entity.CrmProjectRoomId,
                RoomViewRoomId = entity.RoomViewRoomId
            };
        }
    }
}
