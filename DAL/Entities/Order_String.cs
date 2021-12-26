namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order String")]
    public partial class Order_String
    {
        public int amount { get; set; }

        public decimal cost { get; set; }

        public int good { get; set; }

        public int ord { get; set; }

        public int id { get; set; }

        public virtual Good Good1 { get; set; }

        public virtual Order Order { get; set; }
    }
}
