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
    
    public partial class tblDoc
    {
        public tblDoc()
        {
            this.tblDocApproval = new HashSet<tblDocApproval>();
        }
    
        public int DOCID { get; set; }
        public int DTID { get; set; }
        public string DOC_Num { get; set; }
        public string DOC_Rev { get; set; }
        public string DOC_Title { get; set; }
        public string DOC_URL { get; set; }
    
        public virtual tblDocType tblDocType { get; set; }
        public virtual ICollection<tblDocApproval> tblDocApproval { get; set; }
    }
}
