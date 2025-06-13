using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.service;
using Microsoft.AspNetCore.Mvc;

namespace lanchonete.controller;

[ApiController]
[Route("api/item")]
public class ItemController: ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }
    [HttpPost]
    public async Task<ActionResult> createItem([FromBody] RequestCreateItemDto dto)
    {
        await _itemService.createItem(dto);
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> getItemById(string id)
    {
        var item = await _itemService.getItemById(id);
        return Ok(item);
    }

    [HttpGet]
    public async Task<ActionResult> getAllItems(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "size")] int size = 10)
    {
        var data = await _itemService.GetAllItems(page, size);
        return Ok(data);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> updateItemByid(string id ,[FromBody] RequestUpdateItemDto dto)
    {
        await _itemService.updateItemById(id , dto);
        return Ok();
    }
    [HttpDelete]
    public async Task<ActionResult> deleteItemById(string id)
    {
        await _itemService.deleteItemById(id);
        return Ok();
    }
    
}