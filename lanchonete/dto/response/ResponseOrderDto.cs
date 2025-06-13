using lanchonete.enums;
using lanchonete.model;
using MongoDB.Driver;

namespace lanchonete.dto.response;

public record ResponseOrderDto(string id, string user_id , List<ItemOrdered> items, decimal price , StatusEnum status);