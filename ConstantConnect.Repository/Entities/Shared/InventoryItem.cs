using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.Shared
{
    public class InventoryItem
    {
        public Guid Id { get; set; }

        public Guid ClientRoomId { get; set; }
        public string ClientRoomName { get; set; }

        public Guid InventoryItemLoactionId { get; set; }
        public string InventoryItemLoactionName { get; set; }

        public Guid InventoryItemServiceLoactionId { get; set; }
        public string InventoryItemServiceLoactionName { get; set; }

        public Guid ManufactuerId { get; set; }
        public string ManufacturerName { get; set; }

        public Guid EquipmentTypeId { get; set; }
        public string EquipmentTypeName { get; set; }

        public Guid EquipmentFunctionId { get; set; }
        public string EquipmentFunctionName { get; set; }

        public Guid EquipmentStatusId { get; set; }
        public string EquipmentStatusName { get; set; }

        public string Name { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string PartNumber { get; set; }
        public string PartDescription { get; set; }
        public string LocationInRoom { get; set; }
        public string AssetId { get; set; }
        public string Barcode { get; set; }
        public string BenAssetTag { get; set; }
        public string BenAssetNumber { get; set; }
        public string Frimware { get; set; }
        public bool Loanable { get; set; }
        public string LoanContactName { get; set; }
        public string LoanContactInformation { get; set; }
        public string PoNumber { get; set; }
        public string RmaNumber { get; set; }
        public string WcitTag { get; set; }
        public string Notes { get; set; }
        public string Model { get; internal set; }
    }
}
