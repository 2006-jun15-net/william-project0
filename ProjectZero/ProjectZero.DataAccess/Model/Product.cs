using System;
using System.Collections.Generic;

namespace ProjectZero.DataAccess.Model
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            StoreOrder = new HashSet<StoreOrder>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<StoreOrder> StoreOrder { get; set; }
    }
}
