using System.Collections.Generic;
using ProjectZero.Library.Interfaces;
using ProjectZero.Library.Model;

namespace ProjectZero
{
    internal class ProZeroRepo : IProZeroRepo
    {
        private ProZeroContext _dbContext;

        public ProZeroRepo(ProZeroContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void AddObject(object obj)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayObjectDetails(object obj)
        {
            throw new System.NotImplementedException();
        }

        public object GetObjectById(int id, int? id2)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<object> GetOrders(object searchBy)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}