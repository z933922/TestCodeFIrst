using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEF
{

    [Table("M1")]
    public class M1
    {

        public M1()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [StringLength(10)]
        public string Name { get; set; }


        public int ParentId { get; set; }

        public virtual M1 M1Model { set; get; }

        public virtual ICollection<M1> M1List { get; set; }

        public virtual ICollection<M2> M2List { get; set; }
    }
}
