namespace lanchonete.dto.response;

public record ResponsePaginationItemDto(int page , int size, List<ResponseItemDto>? items);