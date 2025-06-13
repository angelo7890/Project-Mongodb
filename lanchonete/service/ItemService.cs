using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.interfaces;
using lanchonete.model;

namespace lanchonete.service;

public class ItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task createItem(RequestCreateItemDto dto)
    {
        await _itemRepository.CreateAsync(new ItemModel(dto.name, dto.description, dto.category, dto.price));
    }

    public async Task<ResponseItemDto> getItemById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }

        var user = await _itemRepository.GetByIdAsync(id);
        return new ResponseItemDto(user.id, user.name, user.description, user.category, user.price);
    }

    public async Task<ResponsePaginationItemDto> GetAllItems(int page, int size)
    {
        var items = await _itemRepository.GetAllAsync(page, size);

        var data = items
            .Select(i => new ResponseItemDto(
                i.id,
                i.name,
                i.description,
                i.category,
                i.price))
            .ToList();

        return new ResponsePaginationItemDto(page, size, data);
    }

    public async Task updateItemById(string id, RequestUpdateItemDto dto)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        await _itemRepository.UpdateAsync(id, new ItemModel(dto.name, dto.description, dto.category, dto.price));
    }

    public async Task deleteItemById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo ou vazio");
        }
        await _itemRepository.DeleteAsync(id);
    }
}