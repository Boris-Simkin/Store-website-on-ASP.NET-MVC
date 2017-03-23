using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    //[ComplexType]
    public class ProductImage
    {
        [Column(TypeName = "image")]
        public byte[] Picture1 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Picture2 { get; set; }
        [Column(TypeName = "image")]
        public byte[] Picture3 { get; set; }

    }
}
