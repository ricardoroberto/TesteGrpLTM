﻿using Commom.Contracts;
using MongoDB.Driver;

namespace Commom.Infra.MongoDB.Units
{
    public class UnitOfWork : IUnitOfWork
    {
        string _mongoDbConnString = "";
        string _mongoDbName = "";

        public UnitOfWork(string mongoDBString, string dataBaseName)
        {
            _mongoDbConnString = mongoDBString;
            _mongoDbName = dataBaseName;
        }

        public TEntity GetSession<TEntity>() where TEntity : class
        {
            var mongoClient = new MongoClient(_mongoDbConnString);
            var mongoServer = mongoClient.GetServer();

            var db = mongoServer.GetDatabase(_mongoDbName);

            return db as TEntity;
        }
    }
}
