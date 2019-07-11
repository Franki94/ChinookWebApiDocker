using Chinook.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.WebApi.Repository
{
    public interface IUnitOfWork
    {
        DataBaseSelector DataBaseSelector {get;}

        IRepository<Album> Album { get;}
    }
}
