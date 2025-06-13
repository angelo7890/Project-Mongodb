using lanchonete.dto;
using lanchonete.service;
using Microsoft.AspNetCore.Mvc;

namespace lanchonete.controller;

[ApiController]
[Route("api/order")]
public class OrderController: ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult> createOrder([FromBody] RequestCreateOrderDto dto)
    {
        await  _orderService.createOrder(dto);
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> getOrderById(string id)
    {
        var order =  await _orderService.getOrderById(id);
        return Ok(order);
    }

    [HttpGet]
    public async Task<ActionResult> getAllOrders(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "size")] int size = 10)
    {
        var data  = await _orderService.getAllOrders(page, size);
        return Ok(data);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> updateStatusOrder(string id, [FromBody] RequestUpdateStatusOrderDto dto)
    {
        await _orderService.updateStatusOrderById(id, dto.status);
        return Ok();
    }
    [HttpDelete]
    public async Task<ActionResult> deleteOrderById(string id)
    {
        await _orderService.deleteOrderById(id);
        return Ok();
    }
}