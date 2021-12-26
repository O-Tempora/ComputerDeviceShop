namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basket")]
    public partial class Basket
    {
        public int id { get; set; }

        public int amount { get; set; }

        public int customer { get; set; }

        public int good { get; set; }

        public virtual Customer Customer1 { get; set; }

        public virtual Good Good1 { get; set; }
    }
}
