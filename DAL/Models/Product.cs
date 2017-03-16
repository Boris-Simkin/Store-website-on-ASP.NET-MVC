using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public ICollection<User> Owners { get; set; }
        public ICollection<User> Users { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
    }
}
