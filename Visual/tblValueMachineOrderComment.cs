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
    
    public partial class tblValueMachineOrderComment
    {
        public int VOCID { get; set; }
        public int VOID { get; set; }
        public int VMCTID { get; set; }
        public int ASID { get; set; }
        public string VOC_Comment { get; set; }
        public Nullable<System.DateTime> VOC_Deleted { get; set; }
        public System.DateTime VOC_TimeStamp { get; set; }
    
        public virtual tblValueMachineCommentType tblValueMachineCommentType { get; set; }
        public virtual tblValueMachineOrder tblValueMachineOrder { get; set; }
    }
}
