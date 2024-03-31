using System;
using DarkWorldChar.Model.MainModel;
using MongoDB.Driver;

namespace DarkWorldChar.Repositories.Implementations
{
	internal abstract class MongoRepository<T> : IDisposable
		where T : Entity, new()
	{
		protected IMongoDatabase Database { get; set; }
		protected IMongoCollection<T> ListOfEntities { get; set; }

		private void InitCollection()
		{
			var settings = new MongoCollectionSettings();
			settings.AssignIdOnInsert = false;
			ListOfEntities = Database.GetCollection<T>(typeof(T).Name, settings);
		}

		public MongoRepository(IMongoDatabase database)
		{
			Database = database;
			InitCollection();
		}

		public void Dispose()
		{
			ListOfEntities = null;
			Database = null;
		}

		protected FilterDefinition<T> FilterEmpty()
		{
			return FilterDefinition<T>.Empty;
		}

		protected FilterDefinition<T> FilterCode(string code)
		{
			return Builders<T>.Filter.Eq("Code", code);
		}

		protected FilterDefinition<T> FilterCombined(params FilterDefinition<T>[] filters)
		{
			var combined = FilterDefinition<T>.Empty;
			foreach (var filter in filters)
				combined = Builders<T>.Filter.And(combined, filter);

			return combined;
		}
	}
}
