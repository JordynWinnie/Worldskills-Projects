//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session_6_22_12_2019
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmergencyMaintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EmergencyMaintenance()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public long ID { get; set; }
        public long AssetID { get; set; }
        public long PriorityID { get; set; }
        public string DescriptionEmergency { get; set; }
        public string OtherConsiderations { get; set; }
        public System.DateTime EMRequestDate { get; set; }
        public Nullable<System.DateTime> EMStartDate { get; set; }
        public Nullable<System.DateTime> EMEndDate { get; set; }
        public string EMTechnicianNote { get; set; }
    
        public virtual Asset Asset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
