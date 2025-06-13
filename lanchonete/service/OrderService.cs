using lanchonete.dto;
using lanchonete.dto.response;
using lanchonete.enums;
using lanchonete.interfaces;
using lanchonete.model;

namespace lanchonete.service;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IAdditionalRepository _additionalRepository;

    public OrderService(IOrderRepository orderRepository, IItemRepository itemRepository, IAdditionalRepository additionalRepository)
    {
        _orderRepository = orderRepository;
        _itemRepository = itemRepository;
        _additionalRepository = additionalRepository;
    }

    public async Task createOrder(RequestCreateOrderDto dto)
    {
        if (string.IsNullOrEmpty(dto.user_id))
        {
            throw new Exception("id do usuario e obrigatorio");
        }

        if (dto.items.Count == 0)
        {
            throw new Exception("e necessario no minimo 1 item para criar o pedido");
        }
        var totalForitems = await priceForItem(dto.items);
        await _orderRepository.CreateAsync(new OrderModel(dto.user_id, dto.items, totalForitems, StatusEnum.CRIADO));
    }

    public async Task<ResponseOrderDto> getOrderById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id nao pode ser nulo");
        }
        var order = await _orderRepository.GetByIdAsync(id);
        return new ResponseOrderDto(order.id , order.user_id , order.items , order.total , order.status);
    }

    public async Task<ResponsePaginationOrderDto> getAllOrders(int page, int size)
    {
        var orders = await _orderRepository.GetAllAsync(page, size);
        var data = orders.Select(o=> new ResponseOrderDto(o.id , o.user_id , o.items , o.total , o.status)).ToList();
        return new ResponsePaginationOrderDto(page, size, data);
    }

    public async Task updateStatusOrderById(string id, StatusEnum status)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id do usuario e obrigatorio");
        }
        await _orderRepository.UpdateAsync(id, status);
    }

    public async Task deleteOrderById(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("id do usuario e obrigatorio");
        }
        await _orderRepository.DeleteAsync(id);
    }

    private async Task<decimal> priceForItem(List<ItemOrdered> items)
    {
        decimal totalPrice = 0;
        foreach (var itemOrdered in items)
        {
            var item = await _itemRepository.GetByIdAsync(itemOrdered.item_id);
            if (item != null)
            {
                totalPrice += item.price * itemOrdered.quantity;
            }

            if (itemOrdered.additional != null && itemOrdered.additional.Count > 0)
            {
                totalPrice += await priceForAdditional(itemOrdered.additional);
            }
        }

        return totalPrice;
    }

    private async Task<decimal> priceForAdditional(List<AdditionalOrdered> additionals)
    {
        decimal totalPrice = 0;
        foreach (var additional in additionals)
        {
            var additionalItem = await _additionalRepository.GetByIdAsync(additional.additional_id);
            if (additionalItem != null)
            {
                totalPrice += additionalItem.price;
            }
        }

        return totalPrice;
    }
    
}