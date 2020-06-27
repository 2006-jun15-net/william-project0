using System;
using System.Collections.Generic;

namespace ProjectZero.Library.Model
{
    public partial class StoreOrder
    {
        public int? Amount { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual OrderHistory Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
