//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryWeb.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cash_fines
    {
        public int ID { get; set; }
        public Nullable<int> MEMBER { get; set; }
        public Nullable<int> TRANSACTION_ { get; set; }
        public Nullable<System.DateTime> START { get; set; }
        public Nullable<System.DateTime> FINISH { get; set; }
        public Nullable<decimal> MONEY { get; set; }
    
        public virtual Members Members { get; set; }
        public virtual Transactions Transactions { get; set; }
    }
}
