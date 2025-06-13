namespace lanchonete.dto.response;

public record ResponsePaginationOrderDto(int page, int size, List<ResponseOrderDto> data);