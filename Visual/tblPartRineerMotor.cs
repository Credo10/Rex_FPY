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
    
    public partial class tblPartRineerMotor
    {
        public int PARTRID { get; set; }
        public int PARTID { get; set; }
        public string Motor { get; set; }
        public Nullable<System.DateTime> PARTR_Deleted { get; set; }
        public Nullable<int> RMTID { get; set; }
    
        public virtual tblPart tblPart { get; set; }
    }
}
