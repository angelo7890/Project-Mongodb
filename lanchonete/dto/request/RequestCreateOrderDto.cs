using lanchonete.model;

namespace lanchonete.dto;

public record RequestCreateOrderDto(string user_id, List<ItemOrdered> items);