//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Visual
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblValueMachineCastingPart
    {
        public int CASPID { get; set; }
        public int PARTID { get; set; }
        public int CASTID { get; set; }
        public Nullable<decimal> CASP_SetupTime { get; set; }
        public System.DateTime CASPID_Created { get; set; }
        public Nullable<System.DateTime> CASPID_Deleted { get; set; }
    
        public virtual tblPart tblPart { get; set; }
        public virtual tblValueMachineCastings tblValueMachineCastings { get; set; }
    }
}
