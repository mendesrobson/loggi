using App.Domain.Core.Models;
using App.Domain.Models;
using GFT.Fleury.Pepilines.Interfaces;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;

namespace App.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class  // BaseEntity
    {
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> obj);
        void Insert(TEntity obj);
        int Insert(IEnumerable<TEntity> list);
        TEntity Get(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity Get(IWorkingContext context, string comandQuery);
        IEnumerable<TEntity> GetAll(IWorkingContext context, string comandQuery);
    }
}
