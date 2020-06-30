using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectZero.Library.RunnerClasses
{
    public class StoreOrder
    {
        private int? _amount;

        public int? Amount
        {
            get => _amount;
            set
            {
                if (value > -1)
                {
                    _amount = value;
                }
                else
                {
                    throw new Exception("Amount must not be null.");
                }
            }
        }

        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}



//public partial class StoreOrder
//{
//    public int? Amount { get; set; }
//    public int ProductId { get; set; }
//    public int OrderId { get; set; }

//    public virtual OrderHistory Order { get; set; }
//    public virtual Product Product { get; set; }
//}