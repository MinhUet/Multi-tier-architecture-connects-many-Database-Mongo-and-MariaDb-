using BVMinh.DemoArchitecture.Entity.DatabaseSetting;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.DL.DatabaseContexts
{
    public class MongoDatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoClient _mongoClient;

        public MongoDatabaseContext(IDatabaseSetting settings)
        {
            _mongoClient = new MongoClient(settings.ConnectionString);
            _mongoDatabase = _mongoClient.GetDatabase(settings.DatabaseName);
        }

        public IMongoDatabase MongoDatabase { get => _mongoDatabase; }
    }
}
