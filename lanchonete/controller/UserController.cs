using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.service;
using Microsoft.AspNetCore.Mvc;

namespace lanchonete.controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> createUser([FromBody] RequestCreateUserDto dto)
    {
        await  _userService.createUser(dto);
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> getUserById(string id)
    {
       var user = await _userService.getUserById(id);
       return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult> getAllUsers(
        [FromQuery(Name = "page")] int page = 1,
        [FromQuery(Name = "size")] int size = 10)
    {
        var data =  await _userService.getAllUsers(page, size);
        return Ok(data);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> updateUser(string id ,[FromBody] RequestUpdateUserDto dto)
    {
        await _userService.updateUserById(id , dto);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> deleteUser(string id)
    {
        await _userService.deleteUserById(id);
        return Ok();
    }
}