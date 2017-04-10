using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.DTO.ConstantConnect
{
    public class Test
    {
        public long TestId { get; set; } // TestID (Primary key)
        public long TestTypeId { get; set; } // TestTypeID
        public string ResultType { get; set; } // ResultType (length: 50)
        public string ResultDimension { get; set; } // ResultDimension (length: 50)
        public byte SortOrder { get; set; } // SortOrder
        public string TestName { get; set; } // TestName (length: 50)
        public string TestDescription { get; set; } // TestDescription
        public short? TechLevel { get; set; } // TechLevel
        public int? Frequency { get; set; } // Frequency

        ///<summary>
        /// Link to CRM Organization ID
        ///</summary>
        public System.Guid? OwnerId { get; set; } // OwnerID
        public short? Active { get; set; } // Active
        public long? ParentTestId { get; set; } // ParentTestID

        ///<summary>
        /// character code used in URL calls to identify test
        ///</summary>
        public string UrlCode { get; set; } // URLCode (length: 50)
        public long? SubSystemId { get; set; } // SubSystemID
        public long? GenericId { get; set; } // GenericID
        public string Cavspid { get; set; } // CAVSPID (length: 50)
    }
}
