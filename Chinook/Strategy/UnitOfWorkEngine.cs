using Chinook.WebApi.Models;
using Chinook.WebApi.Repository;
using Chinook.WebApi.Repository.MySql;
using Chinook.WebApi.Repository.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Chinook.WebApi.Strategy
{
    public class UnitOfWorkEngine : IUnitOfWorkEngine
    {
        //private readonly ChinookMySqlContext _chinookMySqlContext;
        //private readonly ChinookSqlContext _chinookSqlContext;
        private readonly IEnumerable<IUnitOfWork> _unitOfWorks;

        public UnitOfWorkEngine(IEnumerable<IUnitOfWork> unitOfWorks/*, ChinookMySqlContext chinookMySqlContext, ChinookSqlContext chinookSqlContext*/)
        {
            //_chinookMySqlContext = chinookMySqlContext;
            //_chinookSqlContext = chinookSqlContext;
            _unitOfWorks = unitOfWorks;
        }

        public IUnitOfWork GetUnitOfWork(DataBaseSelector dataBaseSelector)
        {
            //if (dataBaseSelector == DataBaseSelector.SqlServer)
            //{
            //    return new SqlServerUnitOfWork(_chinookSqlContext);
            //}
            //return new MySqlUnitOfWork(_chinookMySqlContext);

            return _unitOfWorks.First(x => x.DataBaseSelector == dataBaseSelector);
        }
    }

    public interface IUnitOfWorkEngine
    {
        IUnitOfWork GetUnitOfWork(DataBaseSelector dataBaseSelector);
    }
}
