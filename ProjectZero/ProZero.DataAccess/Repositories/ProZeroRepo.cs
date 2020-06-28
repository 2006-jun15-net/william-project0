using System;
using ProjectZero.Library.Interfaces;

namespace ProjectZero.DataAccess.Repositories
{
    
    public class ProZeroRepo : IProZeroRepo
    {
        private readonly ProZeroContext _dbContext;

        private static readonly ILogger s_logger = LogManager.GetCurrentClassLogger();

        
        
        public void Save()
        {
            s_logger.Info("Saving changes to the database");
            _dbContext.SaveChanges();
        }
    }
}
