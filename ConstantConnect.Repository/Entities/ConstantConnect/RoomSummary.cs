namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RoomSummary
    {
        public long LineId { get; set; } // LineID
        public System.Guid RoomId { get; set; } // RoomID (Primary key)
        public string RoomName { get; set; } // RoomName (length: 75)
        public short? VtcStatus { get; set; } // VTCStatus
        public short? AtcStatus { get; set; } // ATCStatus
        public short? ControlStatus { get; set; } // ControlStatus
        public short? PresentationStatus { get; set; } // PresentationStatus
        public short? OnlineStatus { get; set; } // OnlineStatus
        public System.DateTime? TestDate { get; set; } // TestDate
        public System.Guid? CrmProjectRoomId { get; set; } // CRM_ProjectRoomID
        public System.Guid? RoomViewRoomId { get; set; } // RoomView_RoomID

        // Foreign keys
        public virtual RoomDetail RoomDetail { get; set; } // FK_RoomSummary_RoomDetails
    }
}
