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
    
    public partial class tblValueMachineDown
    {
        public int VMDID { get; set; }
        public int VMCID { get; set; }
        public int VMID { get; set; }
        public int ASID { get; set; }
        public string VMD_Comment { get; set; }
        public bool VMD_Active { get; set; }
        public System.DateTime VMD_Created { get; set; }
        public Nullable<System.DateTime> VMD_Deleted { get; set; }
        public string VMD_Entered { get; set; }
        public Nullable<System.DateTime> VMD_Resolved { get; set; }
        public Nullable<int> VMD_ResolvedASID { get; set; }
        public string VMD_ResolvedAssociate { get; set; }
        public Nullable<int> VMD_Priority { get; set; }
    
        public virtual tblValueMachine tblValueMachine { get; set; }
    }
}