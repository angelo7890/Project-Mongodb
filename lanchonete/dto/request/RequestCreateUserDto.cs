using lanchonete.model;

namespace lanchonete.dto;

public record RequestCreateUserDto(string name, Address address);