//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kazan_Session2_8_11_2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepartmentLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepartmentLocation()
        {
            this.Assets = new HashSet<Asset>();
        }
    
        public long ID { get; set; }
        public long DepartmentID { get; set; }
        public long LocationID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
    }
}
