//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session2_JordanKhong
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int bookingId { get; set; }
        public string userIdFK { get; set; }
        public int packageIdFK { get; set; }
        public int quantityBooked { get; set; }
        public string status { get; set; }
    
        public virtual Package Package { get; set; }
        public virtual User User { get; set; }
    }
}
