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
    
    public partial class Result
    {
        public int resultsId { get; set; }
        public int competitionIdFK { get; set; }
        public int recordsIdFK { get; set; }
        public double q1Marks { get; set; }
        public double q2Marks { get; set; }
        public double q3Marks { get; set; }
        public double q4Marks { get; set; }
        public double totalMarks { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual Competitor Competitor { get; set; }
    }
}
