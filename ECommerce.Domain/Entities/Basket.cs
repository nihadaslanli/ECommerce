using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Basket : Entity
    {
        public int productId { get; set; }

        public Product? product { get; set; }
    }
}
