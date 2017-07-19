namespace EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T2
    {
        public int Id { get; set; }

        public int? TId { get; set; }

        public virtual T1 T1 { get; set; }
    }
}
