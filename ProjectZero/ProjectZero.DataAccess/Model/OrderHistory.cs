using System;
using System.Collections.Generic;

namespace ProjectZero.DataAccess.Model
{
    public partial class OrderHistory
    {
        public OrderHistory()
        {
            StoreOrder = new HashSet<StoreOrder>();
        }

        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreLocation Location { get; set; }
        public virtual ICollection<StoreOrder> StoreOrder { get; set; }
    }
}
