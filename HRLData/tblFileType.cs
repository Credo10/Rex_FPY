
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
    
public partial class tblFileType
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tblFileType()
    {

        this.tblFilePath = new HashSet<tblFilePath>();

    }


    public int FTID { get; set; }

    public int APPID { get; set; }

    public string FT_Desc { get; set; }

    public string FT_Folder { get; set; }

    public Nullable<System.DateTime> FT_Deleted { get; set; }

    public string FT_Suffix { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblFilePath> tblFilePath { get; set; }

}

}
