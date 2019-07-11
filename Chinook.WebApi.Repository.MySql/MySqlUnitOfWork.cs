using Chinook.WebApi.Models;

namespace Chinook.WebApi.Repository.MySql
{
    public class MySqlUnitOfWork : IUnitOfWork
    {
        public DataBaseSelector DataBaseSelector { get; set; }
        public MySqlUnitOfWork(ChinookMySqlContext context)
        {
            DataBaseSelector = DataBaseSelector.MySql;

            Album = new Repository<Album>(context);
        }
        public IRepository<Album> Album { get; private set; }
    }
}
