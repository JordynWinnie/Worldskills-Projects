//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbuDhabu_Session4_12_11_2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class CabinType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CabinType()
        {
            this.AnswerTables = new HashSet<AnswerTable>();
        }
    
        public int cabinTypeId { get; set; }
        public string cabinTypeName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerTable> AnswerTables { get; set; }
    }
}
