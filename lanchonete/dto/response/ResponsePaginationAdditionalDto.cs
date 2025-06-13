namespace lanchonete.dto.response;

public record ResponsePaginationAdditionalDto(int page, int size, List<ResponseAdditionalDto> data);