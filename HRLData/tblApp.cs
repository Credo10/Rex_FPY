
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
    
public partial class tblApp
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tblApp()
    {

        this.tblAppButton = new HashSet<tblAppButton>();

        this.tblAppOptions = new HashSet<tblAppOptions>();

        this.tblAppPath = new HashSet<tblAppPath>();

        this.tblAppReport = new HashSet<tblAppReport>();

        this.tblAppRoles = new HashSet<tblAppRoles>();

        this.tblAppTraining = new HashSet<tblAppTraining>();

    }


    public int APPID { get; set; }

    public string APP_Desc { get; set; }

    public string APP_Version { get; set; }

    public Nullable<int> APP_BetaFor { get; set; }

    public string APP_ReleaseFolder { get; set; }

    public string APP_DesignFolder { get; set; }

    public string APP_EXE { get; set; }

    public string APP_DesignEXE { get; set; }

    public string APP_SolutionFolder { get; set; }

    public Nullable<int> APP_HelpdeskOrg { get; set; }

    public Nullable<System.DateTime> APP_Deleted { get; set; }

    public Nullable<int> APP_Image { get; set; }

    public string APP_Domain { get; set; }

    public string APP_VersionFolder { get; set; }

    public string APP_Color { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppButton> tblAppButton { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppOptions> tblAppOptions { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppPath> tblAppPath { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppReport> tblAppReport { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppRoles> tblAppRoles { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblAppTraining> tblAppTraining { get; set; }

}

}