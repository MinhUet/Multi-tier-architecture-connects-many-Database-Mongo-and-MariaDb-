using BVMinh.DemoArchitecture.Common.Utilities;
using BVMinh.DemoArchitecture.DL.DatabaseContexts;
using BVMinh.DemoArchitecture.DL.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BVMinh.DemoArchitecture.DL.Repositories
{
    public class MongoBaseRepository<T> : IRepository<T> where T : class
    {
        private readonly string _collectionName;
        private readonly MongoDatabaseContext _databaseContext;
        protected readonly IMongoCollection<T> _collection;
        public MongoBaseRepository(IDatabaseContext databaseContext)
        {
            _collectionName = Utility.GetEntityName<T>();
            _databaseContext = (MongoDatabaseContext)databaseContext;
            _collection = _databaseContext.MongoDatabase.GetCollection<T>(_collectionName);
        }

        public virtual async Task<long> Delete(string id)
        {
            var parameterExpression = Expression.Parameter(typeof(T), "object");
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, typeof(T).Name + "ID");
            var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(string)));
            var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);
            var deleteResult = await _collection.DeleteOneAsync(lambdaExpression);
            return deleteResult.DeletedCount;
        }

        public virtual async Task<IQueryable<T>> GetAll()
        {
            var entities = _collection.AsQueryable<T>();
            return entities;
        }

        public virtual async Task<T> GetById(string id)
        {
            var parameterExpression = Expression.Parameter(typeof(T), "object");
            var propertyOrFieldExpression = Expression.PropertyOrField(parameterExpression, typeof(T).Name + "ID");
            var equalityExpression = Expression.Equal(propertyOrFieldExpression, Expression.Constant(id, typeof(string)));
            var lambdaExpression = Expression.Lambda<Func<T, bool>>(equalityExpression, parameterExpression);
            var entity = await (await _collection.FindAsync(lambdaExpression)).FirstAsync();
            return entity;
        }

        public virtual Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<string> Insert(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return (string)entity.GetType().GetProperty(typeof(T) + "ID").GetValue(entity);
        }
    }
}
