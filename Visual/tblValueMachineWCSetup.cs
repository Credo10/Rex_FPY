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
    
    public partial class tblValueMachineWCSetup
    {
        public int WSID { get; set; }
        public int VWID { get; set; }
        public decimal WS_Process { get; set; }
        public bool WS_Active { get; set; }
        public System.DateTime WS_Created { get; set; }
        public Nullable<System.DateTime> WS_Deleted { get; set; }
        public int SUPID { get; set; }
    
        public virtual tblValueMachineSetup tblValueMachineSetup { get; set; }
        public virtual tblValueMachineWC tblValueMachineWC { get; set; }
    }
}
