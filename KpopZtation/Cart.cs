//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KpopZtation
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cart
    {
        public int CustomerID { get; set; }
        public int AlbumID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
