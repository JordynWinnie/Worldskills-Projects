//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPQR_Session4_9_8_2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class Training_Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Training_Module()
        {
            this.Assign_Training = new HashSet<Assign_Training>();
        }
    
        public int moduleId { get; set; }
        public int userTypeIdFK { get; set; }
        public int skillIdFK { get; set; }
        public string moduleName { get; set; }
        public int durationDays { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assign_Training> Assign_Training { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual User_Type User_Type { get; set; }
    }
}
