using lanchonete.model;

namespace lanchonete.dto.response;

public record ResponseUserDto(string id , string name, Address address);