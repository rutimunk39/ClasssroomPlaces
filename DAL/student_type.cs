//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class student_type
    {
        public int id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<int> type_kod { get; set; }
        public Nullable<bool> ok { get; set; }
    
        public virtual seat_type seat_type { get; set; }
        public virtual students students { get; set; }
    }
}
