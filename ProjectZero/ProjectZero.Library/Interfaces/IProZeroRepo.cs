using System;
using System.Collections.Generic;

namespace ProjectZero.Library.Interfaces
{
    public interface IProZeroRepo
    {
        IEnumerable<Object> GetOrders(Object searchBy);

        Object GetObjectById(int id, int? id2);

        void AddObject(Object obj);

        /// Display details of a single order.
        void DisplayObjectDetails(Object obj);

        void Save();
    }
}
