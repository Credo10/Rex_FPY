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
    
    public partial class tblValueMachineOrderOp
    {
        public tblValueMachineOrderOp()
        {
            this.tblValueMachineOrderOpManualConfirmErr = new HashSet<tblValueMachineOrderOpManualConfirmErr>();
        }
    
        public int VPID { get; set; }
        public int VOID { get; set; }
        public int VWID { get; set; }
        public int VNID { get; set; }
        public Nullable<System.DateTime> VP_StartDate { get; set; }
        public Nullable<System.DateTime> VP_FinishDate { get; set; }
        public System.DateTime VP_TimeStamp { get; set; }
        public System.DateTime VP_Updated { get; set; }
        public Nullable<decimal> VP_ProcessingTime { get; set; }
        public string VP_ProcessingMin { get; set; }
        public string VP_OpOrder { get; set; }
        public string VP_SAPStatus { get; set; }
        public Nullable<int> VP_Yield { get; set; }
        public Nullable<System.DateTime> VP_Deleted { get; set; }
        public Nullable<int> VP_OpSort { get; set; }
        public string VP_Confirmation { get; set; }
        public Nullable<int> VP_PrintAttempts { get; set; }
        public bool VP_Open { get; set; }
        public Nullable<int> VP_Row { get; set; }
        public Nullable<int> VP_Rank { get; set; }
        public Nullable<System.DateTime> VP_AddedLater { get; set; }
        public Nullable<System.DateTime> VP_RemovedLater { get; set; }
        public Nullable<int> VP_Scrap { get; set; }
    
        public virtual tblValueMachineOpList tblValueMachineOpList { get; set; }
        public virtual tblValueMachineOrder tblValueMachineOrder { get; set; }
        public virtual tblValueMachineWC tblValueMachineWC { get; set; }
        public virtual ICollection<tblValueMachineOrderOpManualConfirmErr> tblValueMachineOrderOpManualConfirmErr { get; set; }
    }
}
