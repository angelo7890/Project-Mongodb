using lanchonete.enums;
using lanchonete.interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lanchonete.service;

public class AggregationsService
{
    private readonly IAggregationInterface  _aggregationInterface;

    public AggregationsService(IAggregationInterface aggregationInterface)
    {
        _aggregationInterface = aggregationInterface;
    }

    public async Task<List<Dictionary<string, object>>> getOrdersByStatus(StatusEnum status)
    {
        if(status == null)
        {
            throw new ArgumentNullException(nameof(status));
        }
       var order= await _aggregationInterface.GetOrdersByStatusAsync(status);
       var result = order.Select(d => MongoDB.Bson.Serialization.BsonSerializer.Deserialize<Dictionary<string, object>>(d)).ToList();
       return result;
    }
}