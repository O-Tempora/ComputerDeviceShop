namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supply")]
    public partial class Supply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supply()
        {
            Supply_String = new HashSet<Supply_String>();
        }

        public int id { get; set; }

        public decimal total_cost { get; set; }

        [Column(TypeName = "date")]
        public DateTime order_date { get; set; }

        public int supplier { get; set; }

        [Column(TypeName = "date")]
        public DateTime? arrival_date { get; set; }

        public virtual Supplier Supplier1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply_String> Supply_String { get; set; }
    }
}
