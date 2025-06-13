using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.service;
using Microsoft.AspNetCore.Mvc;

namespace lanchonete.controller;

[ApiController]
[Route("api/additional")]
public class AdditionalController: ControllerBase
{
    private readonly AdditionalService _additionalService;

    public AdditionalController(AdditionalService additionalService)
    {
        _additionalService = additionalService;
    }

    [HttpPost]
    public async Task<ActionResult> createAdditional([FromBody] RequestCreateAdditionalDto dto)
    {
        await _additionalService.createAdditional(dto);
        return Ok();
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> getAdditionalById(string id)
    {
        await _additionalService.getAdditionalById(id);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> findAllAdditional(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "size")] int size = 10)
    {
        var data = await _additionalService.getAllAdditional(page , size);
        return Ok(data);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> updateAdditional(string id, [FromBody] RequestUpdateAdditionalDto dto)
    {
        await _additionalService.updateAdditionalById(id, dto);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> deleteAdditional(string id)
    {
        await _additionalService.deleteAdditionalById(id);
        return Ok();
    }
    
}