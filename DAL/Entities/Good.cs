namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Good")]
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            Basket = new HashSet<Basket>();
            Order_String = new HashSet<Order_String>();
            Supply_String = new HashSet<Supply_String>();
        }

        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public int current_amount { get; set; }

        [Required]
        public string specifications { get; set; }

        public decimal cost { get; set; }

        public decimal? discount { get; set; }

        public int manufacturer { get; set; }

        public int warranty { get; set; }

        public string picture { get; set; }

        public int category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }

        public virtual Category Category1 { get; set; }

        public virtual Manufacturer Manufacturer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_String> Order_String { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply_String> Supply_String { get; set; }
    }
}
