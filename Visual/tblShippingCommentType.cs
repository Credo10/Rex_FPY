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
    
    public partial class tblShippingCommentType
    {
        public tblShippingCommentType()
        {
            this.tblShippingComment = new HashSet<tblShippingComment>();
        }
    
        public int SHCTID { get; set; }
        public int SHAID { get; set; }
        public string SHCT_Desc { get; set; }
        public int SHCT_Active { get; set; }
        public Nullable<int> SHCT_Color { get; set; }
        public Nullable<int> SHCT_ForeColor { get; set; }
        public Nullable<int> ARID { get; set; }
        public Nullable<System.DateTime> SHCT_Deleted { get; set; }
    
        public virtual tblShippingAction tblShippingAction { get; set; }
        public virtual ICollection<tblShippingComment> tblShippingComment { get; set; }
    }
}
