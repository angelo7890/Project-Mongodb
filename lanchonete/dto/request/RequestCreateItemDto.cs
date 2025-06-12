namespace lanchonete.dto;

public record RequestCreateItemDto(string name, string description, string category, decimal price);