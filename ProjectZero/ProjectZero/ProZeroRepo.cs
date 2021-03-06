using System.Collections.Generic;
using ProjectZero.Library.Interfaces;
using ProjectZero.DataAccess.Model;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjectZero
{
    internal class ProZeroRepo : IProZeroRepo
    {
        private static readonly List<IDisposable> _disposables = new List<IDisposable>();
        private static ProZeroContext _dbContext;

        public static ProZeroContext DbContext
        {
            get
            {
                // If there is no context throw this exception.
                return _dbContext ?? throw new Exception("Connection Lost. Restart program.");
                // 
            }
            set
            {
                _dbContext = value ?? throw new Exception("Failed to connect to database.");
            }
        }

        private async Task CreateProZeroDbContextAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProZeroContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .optionsBuilder;

            var dbContext = new ProZeroContext(optionsBuilder.Options ?? throw new Exception("Failed to create DbContext..."));
            _disposables.Add(dbContext);
            DbContext = dbContext;
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