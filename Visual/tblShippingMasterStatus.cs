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
    
    public partial class tblShippingMasterStatus
    {
        public tblShippingMasterStatus()
        {
            this.tblShippingDetailStatus = new HashSet<tblShippingDetailStatus>();
        }
    
        public int SHMSID { get; set; }
        public string SHMS_Desc { get; set; }
        public int SHMS_Active { get; set; }
        public Nullable<int> SHMS_Ship { get; set; }
        public Nullable<System.DateTime> SHMS_Deleted { get; set; }
    
        public virtual ICollection<tblShippingDetailStatus> tblShippingDetailStatus { get; set; }
    }
}
