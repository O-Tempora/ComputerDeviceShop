namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_String = new HashSet<Order_String>();
        }

        public int id { get; set; }

        public decimal total_cost { get; set; }

        [Column(TypeName = "date")]
        public DateTime order_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? arrival_date { get; set; }

        public int status { get; set; }

        public int customer { get; set; }

        public virtual Customer Customer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_String> Order_String { get; set; }

        public virtual Status Status1 { get; set; }
    }
}
