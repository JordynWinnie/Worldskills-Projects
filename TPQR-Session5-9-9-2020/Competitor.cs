//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPQR_Session5_9_9_2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class Competitor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competitor()
        {
            this.Results = new HashSet<Result>();
        }
    
        public int recordsId { get; set; }
        public string competitorId { get; set; }
        public int skillIdFK { get; set; }
        public string competitorName { get; set; }
        public string competitorCountry { get; set; }
        public int assignedSeat { get; set; }
    
        public virtual Skill Skill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Results { get; set; }
    }
}
