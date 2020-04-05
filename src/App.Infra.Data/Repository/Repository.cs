using App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using Dapper;
using GFT.Fleury.Pepilines.Interfaces;
using System.Data;
using App.Infra.Data.Persistence;

namespace App.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : DbConnectionRepositoryBase, IRepository<TEntity> where TEntity : class
    {
        public abstract IWorkingContext _workContexto { get; set; }

        public abstract DynamicParameters _parametros { get; set; }

        protected IDbConnection _dbConnection { get; set; }

        public abstract void CreateCommandQuerys();

        public Repository(IDbConnectionFactory dbConnectionFactory, 
                          IWorkingContext workContexto) : base(dbConnectionFactory) 
        {
            _workContexto = workContexto;
            CreateCommandQuerys();
        }

        public virtual void Insert(TEntity obj)
        {
            _dbConnection.Insert<TEntity>(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return _dbConnection.Get<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbConnection.GetAll<TEntity>();
        }

        public virtual bool Update(TEntity obj)
        {
            return _dbConnection.Update<TEntity>(obj);
        }

        public virtual bool Delete(IEnumerable<TEntity> obj)
        {
            return _dbConnection.Update<IEnumerable<TEntity>>(obj);
        }

        public bool Delete(TEntity entity)
        {
            return _dbConnection.Delete<TEntity>(entity);
        }

        public int Insert(IEnumerable<TEntity> list)
        {
            return (int)_dbConnection.Insert<IEnumerable<TEntity>>(list);
        }

        public TEntity Get(TEntity obj)
        {
            return _dbConnection.Get<TEntity>(obj);
        }

        public TEntity Get(IWorkingContext context, string comandQuery)
        {
            return _dbConnection.Query<TEntity>(context.GetWorkingData<string>(comandQuery)).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(IWorkingContext context,string comandQuery)
        {
            return _dbConnection.Query<TEntity>(context.GetWorkingData<string>(comandQuery));
        }

        protected TEntity Get(string procudure, DynamicParameters param, CommandType commandType)
        {
            return _dbConnection.Query<TEntity>(procudure, param, commandType: commandType).FirstOrDefault();
        }

        protected IEnumerable<TEntity> GetAll(string procudure, DynamicParameters param, CommandType commandType)
        {
            return _dbConnection.Query<TEntity>(procudure, param, commandType: commandType);
        }

        protected IEnumerable<TEntity> GetAll(string query, DynamicParameters param)
        {
            try
            {
                return _dbConnection.Query<TEntity>(query, param).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
