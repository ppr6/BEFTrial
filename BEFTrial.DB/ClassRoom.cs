//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEFTrial.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassRoom
    {
        public int ClassRoomID { get; set; }
        public string ClassRoomName { get; set; }
        public string Section { get; set; }
        public int ClassTeacherID { get; set; }
    
        public virtual Faculty Faculty { get; set; }
    }
}
