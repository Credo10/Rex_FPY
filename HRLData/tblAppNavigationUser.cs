
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
    
public partial class tblAppNavigationUser
{

    public int AGID { get; set; }

    public int NAVID { get; set; }

    public int ASID { get; set; }

    public string AG_FormItem { get; set; }

    public Nullable<decimal> AG_Height { get; set; }

    public Nullable<decimal> AG_Width { get; set; }

    public System.DateTime AG_Created { get; set; }

    public Nullable<System.DateTime> AG_Deleted { get; set; }



    public virtual tblAppNavigation tblAppNavigation { get; set; }

}

}
