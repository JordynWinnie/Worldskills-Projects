//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPQR_Session3_9_8_2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel_Booking
    {
        public int bookingId { get; set; }
        public int hotelIdFK { get; set; }
        public string userIdFK { get; set; }
        public int numSingleRoomsRequired { get; set; }
        public int numDoubleRoomsRequired { get; set; }
    
        public virtual Hotel Hotel { get; set; }
        public virtual User User { get; set; }
    }
}
