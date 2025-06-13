using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.interfaces;
using lanchonete.model;

namespace lanchonete.service;

public class UserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task createUser(RequestCreateUserDto dto)
    {
        await userRepository.CreateAsync(new UserModel(dto.name, dto.address));
    }

    public async Task<ResponseUserDto> getUserById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        var user  = await userRepository.GetByIdAsync(id);
        return new ResponseUserDto(user.id,user.name, user.address);
    }

    public async Task<ResponsePaginationUserDto> getAllUsers(int page, int size)
    { 
        var user = await userRepository.GetAllAsync(page, size);
        var users = user.Select(u => new ResponseUserDto(u.id, u.name, u.address)).ToList();
        return new ResponsePaginationUserDto(page, size, users);
    }

    public async Task updateUserById(string id, RequestUpdateUserDto dto)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        await userRepository.UpdateAsync(id , new UserModel(dto.name, dto.address));
    }

    public async Task deleteUserById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        await userRepository.DeleteAsync(id);
    }
}