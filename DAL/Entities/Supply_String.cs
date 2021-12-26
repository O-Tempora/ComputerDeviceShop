namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supply String")]
    public partial class Supply_String
    {
        public int amount { get; set; }

        public decimal cost { get; set; }

        public int good { get; set; }

        public int supply { get; set; }

        public int id { get; set; }

        public virtual Good Good1 { get; set; }

        public virtual Supply Supply1 { get; set; }
    }
}
