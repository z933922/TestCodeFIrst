namespace EF2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("T3")]
    public  class T3
    {
        
        public T3()
        {
          
        }
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

      
        public int ParentId { get; set; }

        public virtual T3 T13model { get; set; }


        public virtual ICollection<T3> T33List { get; set; }

        public virtual ICollection<T4> T44List { get; set; }

    }
}
