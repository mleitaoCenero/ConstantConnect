//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventGroup()
        {
            this.Events = new HashSet<Event>();
        }
    
        public long EventGroupID { get; set; }
        public System.DateTime StartCode { get; set; }
        public string StartID { get; set; }
        public string EndID { get; set; }
        public long DeviceID { get; set; }
        public Nullable<System.DateTime> EventStart { get; set; }
        public Nullable<System.DateTime> EventEnd { get; set; }
        public Nullable<long> MinutesOn { get; set; }
        public string CallNumber { get; set; }
        public string CallDisconnectReason { get; set; }
    
        public virtual Device Device { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
