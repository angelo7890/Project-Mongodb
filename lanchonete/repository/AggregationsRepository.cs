using lanchonete.configuration;
using lanchonete.enums;
using lanchonete.interfaces;
using lanchonete.model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace lanchonete.repository;
public class AggregationsRepository : IAggregationInterface
    {
        private readonly IMongoCollection<BsonDocument> _ordersCollection;

        public AggregationsRepository(IOptions<MongodbSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _ordersCollection = database.GetCollection<BsonDocument>("orders");
        }

        // Usuários que mais gastaram
        public async Task<List<BsonDocument>> GetUsersWhoSpentMostAsync()
        {
            var pipeline = new[]
            {
                new BsonDocument("$unwind", "$items"),
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "items" },
                    { "let", new BsonDocument("itemId", "$items.item_id") },
                    { "pipeline", new BsonArray {
                        new BsonDocument("$addFields", new BsonDocument("_idStr", new BsonDocument("$toString", "$_id"))),
                        new BsonDocument("$match", new BsonDocument("$expr", new BsonDocument("$eq", new BsonArray {"$_idStr", "$$itemId"})))
                    }},
                    { "as", "itemDetails" }
                }),
                new BsonDocument("$unwind", "$itemDetails"),
                new BsonDocument("$addFields", new BsonDocument("itemTotal",
                    new BsonDocument("$multiply", new BsonArray {"$items.quantity", "$itemDetails.price"}))),
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", "$user_id" },
                    { "totalSpent", new BsonDocument("$sum", "$itemTotal") }
                }),
                new BsonDocument("$sort", new BsonDocument("totalSpent", -1))
            };

            return await _ordersCollection.Aggregate<BsonDocument>(pipeline).ToListAsync();
        }

        // Pedidos por status
        public async Task<List<BsonDocument>> GetOrdersByStatusAsync(StatusEnum status)
        {
            var pipeline = new[]
            {
                new BsonDocument("$match", new BsonDocument("status", status.ToString())),
                new BsonDocument("$sort", new BsonDocument("_id", 1))
            };

            return await _ordersCollection.Aggregate<BsonDocument>(pipeline).ToListAsync();
        }

        // Categoria mais vendida
        public async Task<List<BsonDocument>> GetBestSellingCategoryAsync()
        {
            var pipeline = new[]
            {
                new BsonDocument("$unwind", "$items"),
                new BsonDocument("$addFields", new BsonDocument("itemObjectId", new BsonDocument("$toObjectId", "$items.item_id"))),
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "items" },
                    { "localField", "itemObjectId" },
                    { "foreignField", "_id" },
                    { "as", "itemDetails" }
                }),
                new BsonDocument("$unwind", "$itemDetails"),
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", "$itemDetails.category" },
                    { "totalSold", new BsonDocument("$sum", "$items.quantity") }
                }),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 },
                    { "category", "$_id" },
                    { "totalSold", 1 }
                }),
                new BsonDocument("$sort", new BsonDocument("totalSold", -1))
            };

            return await _ordersCollection.Aggregate<BsonDocument>(pipeline).ToListAsync();
        }

        // Item mais vendido
        public async Task<List<BsonDocument>> GetBestSellingItemsAsync()
        {
            var pipeline = new[]
            {
                new BsonDocument("$unwind", "$items"),
                new BsonDocument("$addFields", new BsonDocument("itemObjectId", new BsonDocument("$toObjectId", "$items.item_id"))),
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", "$itemObjectId" },
                    { "totalSold", new BsonDocument("$sum", "$items.quantity") }
                }),
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "items" },
                    { "localField", "_id" },
                    { "foreignField", "_id" },
                    { "as", "item" }
                }),
                new BsonDocument("$unwind", "$item"),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 },
                    { "name", "$item.name" },
                    { "totalSold", 1 }
                }),
                new BsonDocument("$sort", new BsonDocument("totalSold", -1))
            };

            return await _ordersCollection.Aggregate<BsonDocument>(pipeline).ToListAsync();
        }
}
