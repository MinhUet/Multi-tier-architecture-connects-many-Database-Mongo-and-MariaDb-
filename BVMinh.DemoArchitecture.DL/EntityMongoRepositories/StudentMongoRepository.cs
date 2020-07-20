using BVMinh.DemoArchitecture.DL.DatabaseContexts;
using BVMinh.DemoArchitecture.DL.Repositories;
using BVMinh.DemoArchitecture.Entity.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.DL.EntityMongoRepositories
{
    
    public class StudentMongoRepository : MongoBaseRepository<Student>
    {
        public StudentMongoRepository(IDatabaseContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Student> GetAll()
        {
            return _collection.AsQueryable().ToList();

        }
    }
}
