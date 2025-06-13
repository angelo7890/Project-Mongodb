namespace lanchonete.dto.response;

public record ResponsePaginationUserDto(int page, int size, List<ResponseUserDto> data);