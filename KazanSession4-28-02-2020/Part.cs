//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KazanSession4_28_02_2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class Part
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Part()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public Nullable<long> EffectiveLife { get; set; }
        public Nullable<bool> BatchNumberHasRequired { get; set; }
        public Nullable<long> MinimumAmount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
