
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace HRLData
{

using System;
    using System.Collections.Generic;
    
public partial class tblAppReport
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tblAppReport()
    {

        this.tblAppReportOption = new HashSet<tblAppReportOption>();

    }


    public int RPID { get; set; }

    public Nullable<int> APPID { get; set; }

    public string RP_Desc { get; set; }

    public string RP_RDL { get; set; }

    public Nullable<System.DateTime> RP_Deleted { get; set; }



    public virtual tblApp tblApp { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppReportOption> tblAppReportOption { get; set; }

}

}
