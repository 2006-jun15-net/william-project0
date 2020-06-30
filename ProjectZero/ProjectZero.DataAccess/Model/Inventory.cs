using System;
using System.Collections.Generic;

namespace ProjectZero.DataAccess.Model
{
    public partial class Inventory
    {
        public int? Amount { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
