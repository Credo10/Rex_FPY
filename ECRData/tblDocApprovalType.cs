//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ECRData
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDocApprovalType
    {
        public tblDocApprovalType()
        {
            this.tblDocAppDetail = new HashSet<tblDocAppDetail>();
        }
    
        public int DAATID { get; set; }
        public string DAAT_Desc { get; set; }
        public string DAAT_DescLong { get; set; }
        public Nullable<System.DateTime> DAAT_Deleted { get; set; }
    
        public virtual ICollection<tblDocAppDetail> tblDocAppDetail { get; set; }
    }
}
