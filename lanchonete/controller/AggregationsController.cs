using lanchonete.enums;
using lanchonete.service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace lanchonete.controller;
[ApiController]
[Route("/aggregation/")]
public class AggregationsController: ControllerBase
{
    private readonly AggregationsService _aggregationService;

    public AggregationsController(AggregationsService aggregationService)
    {
        _aggregationService = aggregationService;
    }

    [HttpGet]
    [Route("{status}")]
    public async Task<Task<List<Dictionary<string, object>>>> getAdditionalById(StatusEnum status)
    {
        return _aggregationService.getOrdersByStatus(status);
    }
}