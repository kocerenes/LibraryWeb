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
    
    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            this.Transactions = new HashSet<Transactions>();
        }
    
        public int ID { get; set; }
        public Nullable<byte> CATEGORY { get; set; }
        public Nullable<int> AUTHOR { get; set; }
        public string NAME { get; set; }
        public string YEAROFPRINTING { get; set; }
        public string PUBLISHINGHOUSE { get; set; }
        public string PAGE { get; set; }
        public Nullable<bool> CASE_ { get; set; }
    
        public virtual Authors Authors { get; set; }
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}